using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Interfaces
{
    public interface ITodoRepository
    {
        TodoItem Get(Guid todoId);

        /// <summary>
        /// Adds new TodoItem object in database.
        /// If object with the same id already exists,
        /// method should throw DuplicateTodoItemException with the message "duplicate id: {id}". 
        /// </summary>
        void Add(TodoItem todoItem);

        /// <summary>
        /// Tries to remove a TodoItem with given id from the database.
        /// </summary>
        /// <returns>True if success, false otherwise</returns>
        bool Remove(Guid todoId);

        /// <summary>
        /// Updates given TodoItem in database.
        /// If TodoItem does not exist, method will add one.
        /// </summary>
        void Update(TodoItem todoItem);

        /// <summary>
        /// Tries to mark a TodoItem as completed in database.
        /// </summary>
        /// <returns>True if success, false otherwise</returns>
        bool MarkAsCompleted(Guid todoId);

        /// <summary>
        /// Gets all ToDoItems, sorted by date created.
        /// </summary>
        /// <returns></returns>
        List<TodoItem> GetAll();

        /// <summary>
        /// Gets all incomplete ToDoObjects in database.
        /// </summary>
        /// <returns></returns>
        List<TodoItem> GetActive();

        /// <summary>
        /// Gets all completed ToDoItem objects in database.
        /// </summary>
        /// <returns></returns>
        List<TodoItem> GetCompleted();

        /// <summary>
        /// Gets all ToDoItem objects in databse that apply the filter.
        /// </summary>
        List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction);
    }
}
