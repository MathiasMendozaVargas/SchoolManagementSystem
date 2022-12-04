using System.Globalization;
namespace SchoolManagementSystem
{
    public class Database
    {
        private bool loginStatus;

        public Database(bool loginStatus){
            this.loginStatus = loginStatus;
        }

        public bool getLoginStatus(){
            return loginStatus;
        }

        public void setLoginStatus(bool newValue){
            loginStatus = newValue;
        }

        public Student? login(string username, string password, Student[] student_list){
            foreach(Student student in student_list){
                if(username == student.getUsername()){
                    if(password == student.getPassword()){
                        return student;
                    }
                }
            }
            return null;
        }

        public Student signUp(string newUsername, string newPassword, string newName, int newAge, int newGrade){
            Student newStudent = new Student(newUsername, newPassword, newName, newAge, newGrade, null);
            return newStudent;
        }
    }
}