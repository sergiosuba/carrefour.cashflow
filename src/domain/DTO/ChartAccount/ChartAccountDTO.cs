using System;

namespace cashflow.domain.DTO
{
    public class ChartAccountDTO
    {
        string Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        DateTime CreationDate { get; set; }
    }
}