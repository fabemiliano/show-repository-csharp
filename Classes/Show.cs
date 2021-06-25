using System;

namespace ShowsRepository
{
  public class Show : BaseEntity
  {

    private Genre Genre { get; set; }
    private string Title { get; set; }
    private string Description { get; set; }
    private int Year { get; set; }
    private bool Delete { get; set; }


    public Show(int id, Genre genre, string title, string description, int year)
    {
      this.Id = id;
      this.Genre = genre;
      this.Title = title;
      this.Description = description;
      this.Year = year;
      this.Delete = false;
    }

    public override string ToString()
    {

      string returned = "";
      returned += "Gênero: " + this.Genre + Environment.NewLine;
      returned += "Título: " + this.Title + Environment.NewLine;
      returned += "Descrição: " + this.Description + Environment.NewLine;
      returned += "Ano de Início: " + this.Year + Environment.NewLine;
      returned += "Excluído: " + this.Delete;
      return returned;
    }

    public string ReturnTitle()
    {
      return this.Title;
    }

    public int ReturnId()
    {
      return this.Id;
    }
    public bool ReturnDeleted()
    {
      return this.Delete;
    }
    public void DeleteShow()
    {
      this.Delete = true;
    }
  }
}