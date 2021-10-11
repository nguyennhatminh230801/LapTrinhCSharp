namespace Bai_3
{
    class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Mark { get; set; }

        public int Scholarship 
        {
            get
            {
                if (Mark > 8)
                {
                    return 500;
                }
                else if (Mark >= 7 && Mark <= 8)
                {
                    return 300;
                }
                else
                {
                    return 0;
                }
            }
        }

        public Student()
        {
            Id = "DEFAULT_ID";
            Name = "DEFAULT_NAME";
            Mark = 0;
        }

        public Student(string id)
        {
            Id = id;
            Name = "DEFAULT_NAME";
            Mark = 0;
        }

        public Student(string id, string name, int mark)
        {
            Id = id;
            Name = name;
            Mark = mark;
        }

        public override string ToString()
        {
            return $"\nID: {Id}" +
                   $"\nTên: {Name}" +
                   $"\nĐiểm: {Mark}" +
                   $"\nHọc Bổng: {Scholarship}";
        }
    }
}
