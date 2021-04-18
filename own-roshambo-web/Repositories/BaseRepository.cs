using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OwnRoshamboWeb.Repositories
{
    public class BaseRepository
    {
        protected DbContextOptions<RoshamboDbContext> _options;
        public BaseRepository(DbContextOptions<RoshamboDbContext> options)
        {
            _options = options;
        }

        public RoshamboDbContext GetContext()
        {
            return new RoshamboDbContext(_options);
        }
    }
}
