using System;

namespace LawPanel.ApiClient.Abstractions.Base
{
    public abstract class Dto
    {
        public DateTime CreatedAt   { get; set; }
        public bool     Enable      { get; set; }
    }
}
