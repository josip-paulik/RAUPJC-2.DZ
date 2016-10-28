using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericList;
using Interfaces;

namespace Models
{
     public class TodoRepository : ITodoRepository
    {
        /// <summary>
        /// Our in memory implementation of database.
        /// </summary>
        private readonly IGenericList<TodoItem> _inMemoryToDoDatabase;

        public TodoRepository(IGenericList<TodoItem> initalDbState = null)
        {
            _inMemoryToDoDatabase = initalDbState ?? new GenericList<TodoItem>();
        }

        /// <summary>
        /// Gets item based on given Guid.
        /// </summary>
        /// <param name="todoId">Given guid</param>
        /// <returns>Gives item back unless it is not found. Then it returns null.</returns>
        public TodoItem Get(Guid todoId)
        {
            return _inMemoryToDoDatabase.FirstOrDefault(t => t.Id == todoId);
        }

        /// <summary>
        /// Adds item into collection(space issue is solved).
        /// </summary>
        /// <param name="todoItem"></param>
        public void Add(TodoItem todoItem)
        { 
            if (!_inMemoryToDoDatabase.Contains(todoItem))
            {
                _inMemoryToDoDatabase.Add(todoItem); 
            }
        }

        /// <summary>
        /// Removes item which has given Guid
        /// </summary>
        /// <param name="todoId">Given Guid</param>
        /// <returns>True if the operation was success, false if it was not.</returns>
        public bool Remove(Guid todoId)
        {
            var itemToBeRemoved = Get(todoId);

            if (itemToBeRemoved == null)
            {
                return false;
            }
            else
            {
                _inMemoryToDoDatabase.Remove(itemToBeRemoved);
                return true;
            }
        }

        /// <summary>
        /// Changes a ToDoItem inside collection, unless it does not exist. Then it adds given item.
        /// Perhaps not an ideal solution, wait for next patch...
        /// </summary>
        /// <param name="todoItem"></param>
        public void Update(TodoItem toDoItem)
        {
            if (Get(toDoItem.Id) != null)
            {
                _inMemoryToDoDatabase.RemoveAt(_inMemoryToDoDatabase.IndexOf(toDoItem));
            }

            Add(toDoItem);
        }

        /// <summary>
        /// Marks an item inside collection as completed.
        /// </summary>
        /// <param name="todoId"></param>
        /// <returns></returns>
        public bool MarkAsCompleted(Guid todoId)
        {
            var requestedItem = Get(todoId);
            if (requestedItem == null)
            {
                return false;
            }
            
            requestedItem.MarkAsCompleted();
            Update(requestedItem);
            return true;
        }

        /// <summary>
        /// Returns whole collection as a list, ordered by date created.
        /// </summary>
        /// <returns>Collection as a list and its elements ordered by date created.</returns>
        public List<TodoItem> GetAll()
        {
            return _inMemoryToDoDatabase.OrderBy(s => s.DateCreated).ToList();
        }

        /// <summary>
        /// Returns all items which are not marked as completed.
        /// </summary>
        /// <returns>All items that are not marked as completed as a list</returns>
        public List<TodoItem> GetActive()
        {
            return _inMemoryToDoDatabase.Where(t => !t.IsCompleted).ToList();
        }

        /// <summary>
        /// Returns al items which are marked as completed.
        /// </summary>
        /// <returns>All items that are marked as completed as a list.</returns>
        public List<TodoItem> GetCompleted()
        {
            return _inMemoryToDoDatabase.Where(t => t.IsCompleted).ToList();
        }

        /// <summary>
        /// Returns all items which satisfy given condintion(filter).
        /// </summary>
        /// <param name="filterFunction">Filter with which we will filter down wished data.</param>
        /// <returns>Data that satisfies given condition(filter).</returns>
        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryToDoDatabase.Where(filterFunction).ToList();
        }
    }
}
