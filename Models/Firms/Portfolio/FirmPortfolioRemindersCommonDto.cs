namespace LawPanel.ApiClient.Models.Firms.Portfolio
{
    public class FirmPortfolioRemindersCommonDto
    {
        public FirmPortfolioReminderCommonDto Renewal01      { get; set; }
        public FirmPortfolioReminderCommonDto Renewal02      { get; set; }
        public FirmPortfolioReminderCommonDto Renewal03      { get; set; }
        public FirmPortfolioReminderCommonDto Renewal04      { get; set; }
        public FirmPortfolioReminderCommonDto Renewal05      { get; set; }
        public FirmPortfolioReminderCommonDto Renewal06      { get; set; }
        public FirmPortfolioReminderCommonDto Cancellation01 { get; set; }
        public FirmPortfolioReminderCommonDto Cancellation02 { get; set; }
        public FirmPortfolioReminderCommonDto Cancellation03 { get; set; }
        public FirmPortfolioReminderCommonDto Cancellation04 { get; set; }


        public FirmPortfolioRemindersCommonDto()
        {
            Renewal01 = new FirmPortfolioReminderCommonDto();
            Renewal02 = new FirmPortfolioReminderCommonDto();
            Renewal03 = new FirmPortfolioReminderCommonDto();
            Renewal04 = new FirmPortfolioReminderCommonDto();
            Renewal05 = new FirmPortfolioReminderCommonDto();
            Renewal06 = new FirmPortfolioReminderCommonDto();

            Cancellation01 = new FirmPortfolioReminderCommonDto();
            Cancellation02 = new FirmPortfolioReminderCommonDto();
            Cancellation03 = new FirmPortfolioReminderCommonDto();
            Cancellation04 = new FirmPortfolioReminderCommonDto();
        }


        public int TotalRemindersCreated()
        {
            var total = 0;

            // Yes, horrible
            if (Renewal01.Selected) total++;
            if (Renewal02.Selected) total++;
            if (Renewal03.Selected) total++;
            if (Renewal04.Selected) total++;
            if (Renewal05.Selected) total++;
            if (Renewal06.Selected) total++;
            if (Cancellation01.Selected) total++;
            if (Cancellation02.Selected) total++;
            if (Cancellation03.Selected) total++;
            if (Cancellation04.Selected) total++;

            return total;
        }

        public override string ToString()
        {
            return
                $"Renewal01: {Renewal01} \n" +
                $"Renewal02: {Renewal02} \n" +
                $"Renewal03: {Renewal03} \n" +
                $"Renewal04: {Renewal04} \n" +
                $"Renewal05: {Renewal05} \n" +
                $"Renewal06: {Renewal06} \n" +
                $"Cancellation01: {Cancellation01} \n" +
                $"Cancellation02: {Cancellation02} \n" +
                $"Cancellation03: {Cancellation03} \n" +
                $"Cancellation04: {Cancellation04} \n";
        }
    }
}