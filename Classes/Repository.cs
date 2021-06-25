using System;
using System.Collections.Generic;
using ShowsRepository.Interfaces;

namespace ShowsRepository
{
  public class Repository : IRepository<Show>
  {
    private List<Show> list = new List<Show>();
    public void Update(int id, Show entity)
    {
      list[id] = entity;
    }

    public void Delete(int id)
    {
      list[id].DeleteShow();
    }

    public void Insert(Show entity)
    {
      list.Add(entity);
    }

    public List<Show> List()
    {
      return list;
    }

    public int NextId()
    {
      return list.Count;
    }

    public Show ReturnById(int id)
    {
      return list[id];
    }
  }
}