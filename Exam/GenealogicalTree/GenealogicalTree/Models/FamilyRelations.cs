namespace GenealogicalTree.Models
{
	public class FamilyRelations
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Mother {  get; set; }	
		public string Father {  get; set; }
		public FamilyRelations() { }
	}
}
