using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Postgres.Models;

public class ImgEvent : Img
{
    public EventEntity Event { get; set; }

    public ImgEvent() { }
}
