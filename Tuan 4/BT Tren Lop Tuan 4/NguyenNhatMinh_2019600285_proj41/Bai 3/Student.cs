namespace Bai_3
{
    class Student
    {
        private string id;
        private string name;
        private int mark;
        private int scholarship;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Mark { get => mark; set => mark = value; }

        public int Scholarship 
        {
            set
            {
                if (mark > 8)
                {
                    scholarship = 500;
                }
                else if (mark >= 7 && mark <= 8)
                {
                    scholarship = 300;
                }
                else
                {
                    scholarship = 0;
                }
            }

            get
            {
                return scholarship;
            }
        }

        public Student()
        {
            id = "";
            name = "";
            mark = 0;
            scholarship = 0;
        }

        public Student(string id)
        {
            this.id = id;
            name = "";
            mark = 0;
            scholarship = 0;
        }

        public Student(string id, string name, int mark)
        {
            this.id = id;
            this.name = name;
            this.mark = mark;

            if (mark > 8)
            {
                scholarship = 500;
            }
            else if (mark >= 7 && mark <= 8)
            {
                scholarship = 300;
            }
            else
            {
                scholarship = 0;
            }
        }

        public override string ToString()
        {
            return $"\nID: {id}" +
                   $"\nTên: {name}" +
                   $"\nĐiểm: {mark}" +
                   $"\nHọc Bổng: {scholarship}";
        }
    }
}
