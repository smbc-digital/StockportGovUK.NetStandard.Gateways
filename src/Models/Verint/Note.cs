using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Verint
{
    public class Note
    {
        public Note() { }

        public Note(long id)
        {
            this.ID = id;
        }

        public Note(long id, string text, DateTime created, string createdBy)
        {
            this.ID = id;
            this.Text = text;
            this.Created = created;
            this.CreatedBy = createdBy;
        }

        public long ID { get; private set; }

        public string Text { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }
    }
}
