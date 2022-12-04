using System.Runtime.ConstrainedExecution;
using System.Linq;
using System;

namespace SchoolManagementSystem
{
    class Program
    {
        public static void Main(string[] args)
        {

            // Initialize Default Data

            Class mathias_science_class = new Class("Science", "Robert", 203);
            Class mathias_math_class = new Class("Advanced Math", "Alex", 145);
            Class camila_art_class = new Class("Art", "Monica", 345);
            Class camila_geography_class = new Class("Geography", "Glenn", 109);

            List<Class> mathias_classes = new List<Class>(){
                mathias_math_class,
                mathias_science_class
            };

            List<Class> camila_classes = new List<Class>(){
                camila_art_class,
                camila_geography_class
            };

            Student student1 = new Student("mathiasmendoza", "password", "Mathias Mendoza", 19, 12, mathias_classes);
            Student student2 = new Student("camilacalderon", "zayne", "Camila Calderon", 18, 11, camila_classes);
            Student[] students_list = {student1, student2};


            Database db = new Database(false);
            Student currentStudent = null;

            while(true){
                if(db.getLoginStatus() == false){
                    currentStudent = init();
                    if(currentStudent!=null){
                        db.setLoginStatus(true);
                        showMenu(currentStudent);
                    }
                }else if(db.getLoginStatus() == true){
                    showMenu(currentStudent);
                }
            }

            


            Student? init(){
                string[] init_options = {"Log In", "Create a new account", "Exit Program"};

                System.Console.WriteLine("\n**************************");
                System.Console.WriteLine(" School Management System ");
                System.Console.WriteLine("**************************");
                for(var i = 0; i<init_options.Length; i++){
                    System.Console.WriteLine(i+1 + ".- " + init_options[i]);
                }

                System.Console.WriteLine("\nChoose option");
                int option = Int32.Parse(Console.ReadLine());

                // LOGIN SECTION
                if(option==1){
                    System.Console.WriteLine("\n**************************");
                    System.Console.WriteLine("*  Login to your account  ");
                    System.Console.WriteLine("**************************");
                    System.Console.WriteLine("Enter your username");
                    string username = Console.ReadLine();
                    System.Console.WriteLine("\nEnter your password");
                    string password = Console.ReadLine();

                    Student student = db.login(username, password, students_list);
                    if(student != null){
                        System.Console.WriteLine("\nSuccessfull login!");
                        return student;
                    }else{
                        System.Console.WriteLine("\nWrong Credentials...");
                        return null;
                    }
                
                // SIGN UP SECTION
                } else if(option==2){
                    System.Console.WriteLine("\n*************************");
                    System.Console.WriteLine("*   Create a new Account  ");
                    System.Console.WriteLine("*************************");
                    System.Console.WriteLine("Enter your new username");
                    string newUsername = Console.ReadLine();

                    System.Console.WriteLine("\nEnter your Full Name");
                    string newName = Console.ReadLine();

                    System.Console.WriteLine("\nHow old are you?");
                    int newAge = Int32.Parse(Console.ReadLine());

                    System.Console.WriteLine("\nEnter your grade");
                    int newGrade = Int32.Parse(Console.ReadLine());
                    
                    System.Console.WriteLine("\nEnter your new password");
                    string password1 = Console.ReadLine();
                    
                    System.Console.WriteLine("\nRepeat your new password");
                    string password2 = Console.ReadLine();

                    if(password1.Equals(password2)){
                        Student currentStudent = db.signUp(newUsername, password2, newName, newAge, newGrade);
                        List<Student> students_listL = new List<Student>(students_list);
                        students_listL.Add(currentStudent);
                        students_list = students_listL.ToArray();
                        System.Console.WriteLine("\nAccount successfully created!");
                        return currentStudent;
                    }else{
                        return null;
                    }
                } else{
                    System.Console.WriteLine("\nExiting program...");
                    Environment.Exit(2);
                    return null;
                }
            }

            void showMenu(Student currentStudent){
                Class advanced_math = new Class("Advanced Math", "Patricia", 435);
                Class art = new Class("Art", "Jessica", 123);
                Class geography = new Class("Geography", "John", 34);
                Class science = new Class("Science", "Carla", 321);
                Class physics = new Class("Physics", "Einstein", 234);
                Class chemistry = new Class("Chemistry", "Freddy", 432);
                Class engineering = new Class("Engineering", "Gerard", 126);

                Class[] available_classes = {advanced_math, art, geography, science, physics, chemistry, engineering};

                string[] menu_options = {"Check out my classes", "Enroll to a new class", "Log out"};

                System.Console.WriteLine("\n*****************************************************");
                System.Console.WriteLine("   Welcome to your personal SMS, " + currentStudent.getName() + "!");
                System.Console.WriteLine("*****************************************************");

                for(var i=0; i<menu_options.Length; i++){
                    System.Console.WriteLine(i+1 + ".- " + menu_options[i]);
                }

                System.Console.WriteLine("\nChoose option");
                int option = Int32.Parse(Console.ReadLine());
                if(option == 1 && currentStudent.getListClasses() == null){
                    System.Console.WriteLine("\n********************************");
                    System.Console.WriteLine("*          My Classes          *");
                    System.Console.WriteLine("********************************");

                    System.Console.WriteLine("Alert: Sorry but currently you're not enroll on any class...");

                }else if(option == 1 && currentStudent.getListClasses() != null){
                    System.Console.WriteLine("\n********************************");
                    System.Console.WriteLine("*          My Classes          *");
                    System.Console.WriteLine("********************************");

                    for(var i = 0; i<currentStudent.getListClasses().Count; i++){
                        System.Console.WriteLine(i+1 + ".- " + currentStudent.getListClasses()[i].className);
                    }
                    System.Console.WriteLine(currentStudent.getListClasses().Count+1 + ".- Go back");
                    System.Console.WriteLine("\nChoose option");
                    int class_choose = Int32.Parse(Console.ReadLine());

                    if(class_choose != currentStudent.getListClasses().Count+1){
                        currentStudent.getListClasses()[class_choose-1].getClassInfo();
                        System.Console.WriteLine("1.- Go back");
                        System.Console.WriteLine("2.- Log out");
                        System.Console.WriteLine("3.- Quit program");

                        System.Console.WriteLine("\nChoose option");
                        int my_classes_decision = Int32.Parse(Console.ReadLine());
                        if(my_classes_decision == 2){
                            currentStudent = null;
                            db.setLoginStatus(false);

                        }else if(my_classes_decision == 3){
                            System.Console.WriteLine("\nQuitting the system...");
                            Environment.Exit(2);
                        }
                    }

                }else if(option == 2){
                    if(currentStudent.getListClasses() != null){
                        for(var i=0; i<currentStudent.getListClasses().Count; i++){
                            for(var x=0; x<available_classes.Length; x++){
                                if(currentStudent.getListClasses()[i].className == available_classes.ElementAt(x).className){
                                    List<Class> available_classes_list = new List<Class>(available_classes);
                                    available_classes_list.RemoveAt(x);
                                    available_classes = available_classes_list.ToArray();
                                }
                            }
                        }
                    }
                    System.Console.WriteLine("\n********************************");
                    System.Console.WriteLine("*       Available Classes      *");
                    System.Console.WriteLine("********************************");
                    for(var i=0; i<available_classes.Length; i++){
                        System.Console.WriteLine(i+1 + ".- " + available_classes[i].className);
                    }
                    System.Console.WriteLine(available_classes.Length+1 + ".- Cancel");
                    System.Console.WriteLine("\nChoose a class");
                    int class_decision = Int32.Parse(Console.ReadLine());
                    if(class_decision != available_classes.Length+1){
                        System.Console.WriteLine("\nAre you sure you wanna enroll to " + available_classes[class_decision-1].className + "?");
                        System.Console.WriteLine("1.- Yes, I do");
                        System.Console.WriteLine("2.- Cancel");
                        System.Console.WriteLine("\nChoose option");
                        int enroll_decision = Int32.Parse(Console.ReadLine());
                        if(enroll_decision == 1){
                            if(currentStudent.getListClasses() != null){
                                currentStudent.getListClasses().Add(available_classes.ElementAt(class_decision-1));
                                currentStudent.setListClasses(currentStudent.getListClasses());
                            }else{
                                Class newClass = new Class(available_classes.ElementAt(class_decision-1).className, available_classes.ElementAt(class_decision-1).teacherName, available_classes.ElementAt(class_decision-1).classroom);
                                List<Class> newStudentClassList = new List<Class>(){newClass};
                                currentStudent.setListClasses(newStudentClassList);
                            }
                            
                            System.Console.WriteLine("Congrats! You just enrolled to " + available_classes.ElementAt(class_decision-1).className + "!");

                        }
                    }
                }else if(option == 3){
                    currentStudent = null;
                    db.setLoginStatus(false);
                }
            }
        }
    }
}