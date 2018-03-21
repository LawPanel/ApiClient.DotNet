using System;
using System.Collections.Generic;
using System.Linq;
using LawPanel.ApiClient.Extensions;

namespace LawPanel.ApiClient.Models.Firms.Portfolio
{
    public class FirmPortfolioRemindersCommonDto
    {
        public FirmPortfolioReminderCommonDto Renewal01         { get; set; }
        public FirmPortfolioReminderCommonDto Renewal02         { get; set; }
        public FirmPortfolioReminderCommonDto Renewal03         { get; set; }
        public FirmPortfolioReminderCommonDto Renewal04         { get; set; }
        public FirmPortfolioReminderCommonDto Renewal05         { get; set; }
        public FirmPortfolioReminderCommonDto Renewal06         { get; set; }
        public FirmPortfolioReminderCommonDto Cancellation01    { get; set; }
        public FirmPortfolioReminderCommonDto Cancellation02    { get; set; }
        public FirmPortfolioReminderCommonDto Cancellation03    { get; set; }
        public FirmPortfolioReminderCommonDto Cancellation04    { get; set; }

        #region Constructor
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
        #endregion

        #region Public helpers

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

        public void SetAllToNonSelected()
        {
            Renewal01.Selected = false;
            Renewal02.Selected = false;
            Renewal03.Selected = false;
            Renewal04.Selected = false;
            Renewal05.Selected = false;
            Renewal06.Selected = false;

            Cancellation01.Selected = false;
            Cancellation02.Selected = false;
            Cancellation03.Selected = false;
            Cancellation04.Selected = false;
        }

        public bool ExistOneSelected()
        {
            return
                Renewal01.Selected ||
                Renewal02.Selected ||
                Renewal03.Selected ||
                Renewal04.Selected ||
                Renewal05.Selected ||
                Renewal06.Selected ||
                Cancellation01.Selected ||
                Cancellation02.Selected ||
                Cancellation03.Selected ||
                Cancellation04.Selected;
        }

        public bool ExistReminderInThePast()
        {
            return Renewal01.DateTime < DateTime.UtcNow ||
                   Renewal02.DateTime < DateTime.UtcNow ||
                   Renewal03.DateTime < DateTime.UtcNow ||
                   Renewal04.DateTime < DateTime.UtcNow ||
                   Renewal05.DateTime < DateTime.UtcNow ||
                   Renewal06.DateTime < DateTime.UtcNow ||
                   Cancellation01.DateTime < DateTime.UtcNow ||
                   Cancellation02.DateTime < DateTime.UtcNow ||
                   Cancellation03.DateTime < DateTime.UtcNow ||
                   Cancellation04.DateTime < DateTime.UtcNow;
        }
        
        public void AddUsersId(List<Guid> userIds)
        {
            AddUsersId(Renewal01, userIds);
            AddUsersId(Renewal02, userIds);
            AddUsersId(Renewal03, userIds);
            AddUsersId(Renewal04, userIds);
            AddUsersId(Renewal05, userIds);
            AddUsersId(Renewal06, userIds);
            AddUsersId(Cancellation01, userIds);
            AddUsersId(Cancellation02, userIds);
            AddUsersId(Cancellation03, userIds);
            AddUsersId(Cancellation04, userIds);
        }

        public void AddNotes(string notes)
        {

            if (string.IsNullOrEmpty(notes)) return;

            AddNotes(Renewal01, notes);
            AddNotes(Renewal02, notes);
            AddNotes(Renewal03, notes);
            AddNotes(Renewal04, notes);
            AddNotes(Renewal05, notes);
            AddNotes(Renewal06, notes);
            AddNotes(Cancellation01, notes);
            AddNotes(Cancellation02, notes);
            AddNotes(Cancellation03, notes);
            AddNotes(Cancellation04, notes);
        }

        public void SelectWhereDateIsOnTheFuture()
        {
            SelectWhereDateIsOnTheFuture(Renewal01);
            SelectWhereDateIsOnTheFuture(Renewal02);
            SelectWhereDateIsOnTheFuture(Renewal03);
            SelectWhereDateIsOnTheFuture(Renewal04);
            SelectWhereDateIsOnTheFuture(Renewal05);
            SelectWhereDateIsOnTheFuture(Renewal06);
            SelectWhereDateIsOnTheFuture(Cancellation01);
            SelectWhereDateIsOnTheFuture(Cancellation02);
            SelectWhereDateIsOnTheFuture(Cancellation03);
            SelectWhereDateIsOnTheFuture(Cancellation04);
        }

        #endregion

        #region Private helpers

        private static void AddUsersId(FirmPortfolioReminderCommonDto firmPortfolioReminderCommon, List<Guid> userIds)
        {
            var isEmpty = string.IsNullOrEmpty(firmPortfolioReminderCommon.UserId);
            
            if (isEmpty) {
                var userIdsString = userIds.Select(m => m.ToString()).ToList().CommaSeparatedItems();
                firmPortfolioReminderCommon.UserId = userIdsString;
            }else{

                foreach (var userId in userIds.Select(m=>m.ToString()))
                {
                    if (!firmPortfolioReminderCommon.UserId.Contains(userId))
                    {
                        firmPortfolioReminderCommon.UserId += $", {userId}";
                    }
                }
            }
        }

        private static void AddNotes(FirmPortfolioReminderCommonDto firmPortfolioReminderCommon, string notes)
        {
            var isEmpty = string.IsNullOrEmpty(firmPortfolioReminderCommon.Notes);
            if (isEmpty) {
                firmPortfolioReminderCommon.Notes = notes;
            } else {
                firmPortfolioReminderCommon.Notes += $". {notes}";
            }
        }

        private static void SelectWhereDateIsOnTheFuture(FirmPortfolioReminderCommonDto firmPortfolioReminderCommon)
        {
            firmPortfolioReminderCommon.Selected = firmPortfolioReminderCommon.DateTime > DateTime.UtcNow;
        }

        #endregion

        #region Overrides

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

        #endregion

    }
}