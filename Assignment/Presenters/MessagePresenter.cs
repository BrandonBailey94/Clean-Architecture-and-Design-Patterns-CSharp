using System.Collections.Generic;

namespace Assignment.Presenters
{
    public class MessagePresenter : IPresenter
    {
        List<string> messages;

        public MessagePresenter(string message)
        {
            messages = new List<string>();
            messages.Add(message);
        }

        public MessagePresenter(List<string> messages)
        {
            this.messages = messages;
        }

        public List<string> GetViewData()
        {
            return messages;
        }
    }
}
