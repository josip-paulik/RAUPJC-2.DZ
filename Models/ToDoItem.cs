using GenericList;
using System;

namespace Models
{
    class ToDoItem
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DateCompleted { get; set; }
        public DateTime DateCreated { get; set; }

        public ToDoItem(string text)
        {
            Id = new Guid();
            Text = text;
            IsCompleted = false;
            DateCreated = DateTime.Now;
        }

        public void MarkAsCompleted()
        {
            if(!IsCompleted)
            {
                IsCompleted = true;
                DateCompleted = DateTime.Now;
            }
        }
    }
}
