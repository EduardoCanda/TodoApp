using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private List<TodoItem> _items;

        public TodoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", "UsuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 2", "UsuarioB", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 3", "UsuarioC", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 4", "UsuarioD", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 5", "eduardocanda", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 6", "eduardocanda", DateTime.Now));
        }

        [TestMethod]
        public void Deve_retornar_tarefas_apenas_do_usuario_eduardocanda()
        {
            var result = _items.Where(TodoQueries);
            
            Assert.Fail();
        }

    }
}