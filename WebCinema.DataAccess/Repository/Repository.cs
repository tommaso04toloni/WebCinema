﻿using WebCinema.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebCinema.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        //dbSet rappresenta il dbSet generico che corrisponderà ad una collection di oggetti. Ad esempio  Categories
        internal DbSet<T> dbSet;
        public Repository(AppDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)

        {

            IQueryable<T> query = dbSet;
            if (filter != null)

            {

                query = query.Where(filter);

            }
            if (includeProperties != null)

            {

                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()))

                {

                    query = query.Include(includeProp);

                }

            }

            return query.ToList();

        }

        public T? GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)

        {

            IQueryable<T> query = dbSet;

            query = query.Where(filter);

            if (includeProperties != null)

            {

                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()))

                {

                    query = query.Include(includeProp);

                }

            }

            return query.FirstOrDefault();

        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
