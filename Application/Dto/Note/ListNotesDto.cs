namespace Application.Dto.Note
{
    public class ListNotesDto
    {

        public int Count { get; set; }
        public IEnumerable<NoteDto> Notes { get; set; }
    }
}
