using System;
using System.Diagnostics;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Helpers.ProcessesStatus
{
    public class ProcessStatusDto : ProcessStatusRecordDto, IIdentifiableDto
    {
        public string   Id                  { get; set; }
        public string   ProcessId           { get; set; }
        public long     UnixTimeStamp       { get; set; }
        public long     UnixTimeStampEvent  { get; set; }
        public bool     Success             { get; set; }


        public string Pk()
        {
            return Id.Split(Convert.ToChar("|"))[0];
        }
        public string Rk()
        {
            return Id.Split(Convert.ToChar("|"))[1];
        }




        public Stopwatch StopWatch { get; set; }


        public ProcessStatusDto()
        {
            StopWatch = new Stopwatch();
            StopWatch.Start();
        }
    }
}
