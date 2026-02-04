using Admin.ViewModel.Lesson;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Models;
using MediatR;

namespace Admin.Commands_Handlers.Managment;

public class SendEntity<T>(T entity) : IRequest
    where T : Entity, new()
{
    public T Entity { get; set; } = entity;
}