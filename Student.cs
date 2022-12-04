namespace SchoolManagementSystem
{
    public class Student
    {
        private string username;
        private string password;
        private string name;
        private int age;
        private int grade;
        private List<Class> list_of_classes;

        public Student(string username, string password, string name, int age, int grade, List<Class> list_of_classes){
            this.username = username;
            this.password = password;
            this.name = name;
            this.age = age;
            this.grade = grade;
            this.list_of_classes = list_of_classes;
        }

        public string getUsername(){
            return username;
        }

        public string getPassword(){
            return password;
        }
        public void setPassword(string newPassword){
            password = newPassword;
        }
        
        public string getName(){
            return name;
        }

        public int getAge(){
            return age;
        }

        public int getGrade(){
            return grade;
        }

        void setGrade(int newGrade){
            this.grade = newGrade;
        }

        public List<Class>? getListClasses(){
            return list_of_classes;
        }

        public void setListClasses(List<Class> newListClasses){
            this.list_of_classes = newListClasses;
        }
    }
}