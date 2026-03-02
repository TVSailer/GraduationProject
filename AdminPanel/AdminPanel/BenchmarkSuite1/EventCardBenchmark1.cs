using BenchmarkDotNet.Attributes;
using System.Windows.Forms;
using Admin.View.Moduls.Event;
using DataAccess.Postgres.Models;
using System.Threading;
using Microsoft.VSDiagnostics;
using System;

namespace Benchmarks
{
    [CPUUsageDiagnoser]
    public class EventCardBenchmark1
    {
        private EventEntity entity;
        private EventCard card;
        [GlobalSetup]
        public void Setup()
        {
            entity = new EventEntity
            {
                Title = "Заголовок",
                Schedule = new EventScheduleEntity(TimeOnly.Parse("09:00"), TimeOnly.Parse("17:00"), DateOnly.Parse("2026-03-02")),
                Location = "Место",
                Organizer = "Организатор",
                CurrentParticipants = 10,
                MaxParticipants = 20
            };
            var setupThread = new Thread(() =>
            {
                card = new EventCard();
                card.Initialize(entity);
            });
            setupThread.SetApartmentState(ApartmentState.STA);
            setupThread.IsBackground = true;
            setupThread.Start();
            setupThread.Join();
        }

        [Benchmark]
        public Control BuildContent()
        {
            Control result = null;
            var thread = new Thread(() =>
            {
                result = card.Content();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
            thread.Join();
            return result;
        }
    }
}
