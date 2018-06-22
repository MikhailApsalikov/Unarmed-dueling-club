namespace DeejayEntertainment.UnarmedDuallingClub.GameCore.Entities
{
	public class MenuOptionEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public MenuOptionEntity(int id, string name)
		{
			this.Id = id;
			this.Name = name;
		}
	}
}
