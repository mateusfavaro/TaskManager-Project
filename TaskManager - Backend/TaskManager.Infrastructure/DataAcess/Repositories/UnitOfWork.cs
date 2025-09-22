using TaskManager.Domain.Repositories.Tasks;

namespace TaskManager.Infrastructure.DataAcess.Repositories
{

    public class UnitOfWork : IUnitOfWork
    {

        private readonly TasksDBContext _dbcontext;

        public UnitOfWork(TasksDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        //Classe responsavel por fazer o savechanges no banco de dados. Sempre utilizar quando for fazer uma escrita no banco de dados.
        //Nao é necessária caso formos fazer apenas a leitura do banco, por esta razão está em classe separada do repository.
        public async Task Commit()
        {
            await _dbcontext.SaveChangesAsync();
        }

    }
}
