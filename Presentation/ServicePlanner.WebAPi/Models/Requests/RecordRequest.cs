﻿#pragma warning disable CS8618
namespace ServicePlanner.WebApi.Models.Requests
{
    public class RecordRequest
    {
        public string Text { get; set; }
        public Guid ProfileId { get; set; }
        public DateOnly Date { get; set; }
    }
}
