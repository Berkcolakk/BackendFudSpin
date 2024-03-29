﻿using Microsoft.EntityFrameworkCore;
using FudSpin.Context.Context;
using FudSpin.Infrastructure.DatabaseFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ProjectContext _context;

        private readonly DbSet<T> _entities;

        protected IDatabaseFactory DatabaseFactory { get; private set; }

        public GenericRepository(IDatabaseFactory databaseFactory) => DatabaseFactory = databaseFactory;

        protected ProjectContext DataContext => _context ??= DatabaseFactory.Get();

        public virtual IQueryable<T> Table => Entities.AsNoTrackingWithIdentityResolution();


        protected virtual DbSet<T> Entities => _entities ?? DataContext.Set<T>();

        public virtual async Task<T> Get(Expression<Func<T, bool>> predicate) => await Task.FromResult( await Table.SingleOrDefaultAsync(predicate));

        public virtual async ValueTask<T> GetById(object id) => await Task.FromResult( await Entities.FindAsync(id));

        public virtual async Task<List<T>> GetMany(Expression<Func<T, bool>> predicate) =>await Task.FromResult( await Table.Where(predicate).ToListAsync());

        public async virtual Task<List<T>> GetManyNoTracking(Expression<Func<T, bool>> predicate) => await Task.FromResult(await Table.Where(predicate).ToListAsync());

        public async Task<List<T>> GetAll() => await Task.FromResult(await Table.ToListAsync());

        public virtual async Task Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException($"{nameof(entity)} must be not null");
                }

                await Entities.AddAsync(entity);
                await Task.CompletedTask;
            }
            catch (Exception dbEx)
            {
                //throw new Exception(GetFullErrorText(dbEx), dbEx);
                throw new Exception(dbEx.Message);
            }
        }

        public virtual async Task Insert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException($"{nameof(entities)} must be not null");
                }

                foreach (T entity in entities)
                {
                    await Entities.AddAsync(entity);
                }
                await Task.CompletedTask;
            }
            catch (Exception dbEx)
            {
                //throw new Exception(GetFullErrorText(dbEx), dbEx);
                throw new Exception(dbEx.Message);
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException($"{nameof(entity)} must be not null");
                }
                Entities.Update(entity);
            }
            catch (Exception dbEx)
            {
                //throw new Exception(GetFullErrorText(dbEx), dbEx);
                throw new Exception(dbEx.Message);
            }
        }

        public virtual void Update(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException($"{nameof(entities)} must be not null");
                }
                Entities.UpdateRange(entities);
            }
            catch (Exception dbEx)
            {
                //throw new Exception(GetFullErrorText(dbEx), dbEx);
                throw new Exception(dbEx.Message);
            }
        }

        public virtual void Update(T entity, params Expression<Func<T, object>>[] noUpdateProperties)
        {
            Entities.Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;

            foreach (Expression<Func<T, object>> property in noUpdateProperties)
            {
                DataContext.Entry(entity).Property(property).IsModified = false;
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException($"{nameof(entity)} must be not null");
                }

                Entities.Remove(entity);
            }
            catch (Exception dbEx)
            {
                //throw new Exception(GetFullErrorText(dbEx), dbEx);
                throw new Exception(dbEx.Message);
            }
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException($"{nameof(entities)} must be not null");
                }

                foreach (T entity in entities)
                {
                    Entities.Remove(entity);
                }
            }
            catch (Exception dbEx)
            {
                //throw new Exception(GetFullErrorText(dbEx), dbEx);
                throw new Exception(dbEx.Message);
            }
        }
    }
}
