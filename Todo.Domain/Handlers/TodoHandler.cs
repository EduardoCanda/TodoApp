using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler :
        Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommand>,
        IHandler<MarkTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            // Fail Fast Validation
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            // Gera o todo
            var todo = new TodoItem(command.Title, command.User, command.Date);

            // Salvar no banco
            _repository.Create(todo);

            return new GenericCommandResult(true, "Tarefa salva", todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            // Fail fast validation
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            // Recura o todoItem (rehidratação)
            var todo = _repository.GetById(command.Id, command.User);

            // Atualiza o todo
            todo.UpdateTitle(command.Title);

            // Salva no banco
            _repository.Update(todo);

            return new GenericCommandResult(true, "Todo atualizado", todo);
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            // Fail fast validation
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            // Recura o todoItem (rehidratação)
            var todo = _repository.GetById(command.Id, command.User);

            // marca como não concluído
            todo.MarkAsUndone();

            // Salva no banco
            _repository.Update(todo);

            // retorna o resultado
            return new GenericCommandResult(true, "Todo atualizado", todo);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            // Fail fast validation
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            // Recura o todoItem (rehidratação)
            var todo = _repository.GetById(command.Id, command.User);

            // marca como concluído
            todo.MarkAsDone();

            // Salva no banco
            _repository.Update(todo);

            // retorna o resultado
            return new GenericCommandResult(true, "Todo atualizado", todo);
        }
    }
}