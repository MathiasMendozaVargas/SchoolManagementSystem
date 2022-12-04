namespace SchoolManagementSystem
{
    public class Class
    {
        public string className;
        public string teacherName;
        public int classroom;

        public Class(string className, string teacherName, int classroom){
            this.className = className;
            this.teacherName = teacherName;
            this.classroom = classroom;
        }
        string getClassName(){
            return className;
        }
        void setClassName(string className){
            this.className = className;
        }
        
        string getTeacherName(){
            return teacherName;
        }
        void setTeacherName(string teacherName){
            this.teacherName = teacherName;
        }

        int getClassRoom(){
            return classroom;
        }
        void setClassRoom(int classroom){
            this.classroom = classroom;
        }
        

        // GET CLASS INFO FUNCTION
        public void getClassInfo(){
            System.Console.WriteLine("\n-----------------------------");
            System.Console.WriteLine("| Teacher's Name: " + teacherName);
            System.Console.WriteLine("| Classroom: " + classroom);
            System.Console.WriteLine("-----------------------------");
        }
    }
}