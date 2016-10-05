using System;
using System.IO;

namespace CodeLou.CSharp.Week3.Challenge
{
	class Program
	{
		static void Main(string[] args)
		{
            // Overview:
            // In this assignment, you will be creating a calendar application that will load and save data. An example of loading and saving data has been provided.
            // This calendar application will accept multiple event types which will be represented by their own class types. 
            // You will be dealing with Appointments, Meetings, and Reminders.

            // Task 1:
            // Create new classes that will represent the calendar items that you will be using. 
            // Each of your classes will inherit from the CalendarItemBase abstract class.
            // Reminders have already been created as an example.

            // Task 2:
            // Define Your Data
            // Appointments need to be assigned a start date and time, an end date and time, and a location.
            // Meetings need to be assigned a start date and time, an end date and time, a location, and attendees. You can decide what data you need for attendees.
            // Reminders need to be assigned a start date and time.
            // Hint: Use inheritance to make your life easier.

            // Task 3:
            // Add the missing code to the ReminderRepository. Hint: Look for instances of NotImplementedException.
            // Create repository classes for Appointments and Meetings. Use the ReminderRepository as an example.

			// Task 4:
			// We want our application to load data and to save data. The process for reminders has already been created. You will need to do the same thing
			// for the other data types.
			var reminderRepository = new ReminderRepository(); 
			if (File.Exists("Reminders.json")) //Note: these files are created in the same folder as your .exe
				//Note: What happens when this file is improperly formatte? Can you handle this case?
				reminderRepository.LoadFromJson<Reminder>(File.ReadAllText("Reminders.json"));

            // Hint: var appointmentRepository = new AppointmentRepository(); etc...
            var appointmentRepository = new AppointmentRepository();
            if (File.Exists("Appointments.json"))
            {
                appointmentRepository.LoadFromJson<Appointment>(File.ReadAllText("Appointments.json"));
            }

            var meetingRepository = new MeetingRepository();
            if (File.Exists("Meetings.json"))
            {
                meetingRepository.LoadFromJson<Meeting>(File.ReadAllText("Meetings.json"));
            }

            // Task 5:
            // Fill in the missing options A, V, F, D for all classes
            var sessionEnded = false;
			while (!sessionEnded)
			{
				Console.WriteLine("Q: save and quit");
				Console.WriteLine("A: add item");
				Console.WriteLine("V: view all");
				Console.WriteLine("F: find by date");
				Console.WriteLine("D: delete an item");
				Console.WriteLine();

				Console.Write("Select an action: ");
				var selectedOption = Console.ReadKey().KeyChar;
				Console.Clear();

				switch (selectedOption)
				{
					case ('Q'):
						//End the session when they select q
						sessionEnded = true;
						break;
					case ('A'):
						Console.WriteLine("A: Appointment");
						Console.WriteLine("M: Meeting");
						Console.WriteLine("R: Reminder");
						Console.WriteLine();
						Console.Write("Select a type:");
						var selectedType = Console.ReadKey().KeyChar;
						Console.Clear();

						switch (selectedType)
						{//switch statements require a "break;", be careful not to experience this error
							case ('A'):
                                Appointment newAppointment =(Appointment)appointmentRepository.Create();
                                string response = "Created New " + newAppointment;
                                Console.WriteLine(response);
                                break;
                            case ('M'):
                                Meeting newMeeting = (Meeting)meetingRepository.Create();
                                response = "Created New " + newMeeting;
                                Console.WriteLine(response);

                                break;
							case ('R'):
								Reminder newReminder = (Reminder)reminderRepository.Create();
                                response = "Created New " + newReminder;
                                Console.WriteLine(response);
								break;
							default:
                                //Note: The $"abc {variable} def" syntax below is new syntactic sugar in C# 6.0 that can be used 
                                //in place of string.Format() in previous versions of C#.
                                Console.WriteLine($"Invalid Type {selectedType}, press any key to continue.");
								Console.Read();
								break;
						}
						
						break;
					case ('V'):

                        //Get everything and call overridden ToString on each item.

                        foreach (var reminder in reminderRepository.GetAllItems())
                        {
                            Console.WriteLine(reminder);
                        }
                        foreach (var appointment in appointmentRepository.GetAllItems())
                        {
                            Console.WriteLine(appointment);
                        }
                        foreach (var meeting in meetingRepository.GetAllItems())
                        {
                            Console.WriteLine(meeting);
                        }
                        break;
					case ('F'):
                        Console.WriteLine("Enter a Date");
                        var input = Console.ReadLine();
                        var searchDate = new DateTime();
                        if (DateTime.TryParse(input, out searchDate))
                        {
                            foreach (var reminder in reminderRepository.FindByDate(searchDate))
                            {
                                Console.WriteLine(reminder);
                            }
                            foreach (var appointment in appointmentRepository.FindByDate(searchDate))
                            {
                                Console.WriteLine(appointment);
                            }
                            foreach (var meeting in meetingRepository.FindByDate(searchDate))
                            {
                                Console.WriteLine(meeting);
                            }
                        }
                            break;
					case ('D'):
                        Console.WriteLine("A: Appointment");
                        Console.WriteLine("M: Meeting");
                        Console.WriteLine("R: Reminder");
                        Console.WriteLine();
                        Console.Write("Select a type:");
                        selectedType = Console.ReadKey().KeyChar;
                        Console.Clear();

                        switch (selectedType)
                        {
                            case ('A'):
                                Console.WriteLine("Enter Id of Appointment to Delete");
                                int toDelete;
                                var response = Console.ReadLine();
                                if (int.TryParse(response, out toDelete))
                                {
                                    appointmentRepository.Delete(appointmentRepository.FindById(toDelete));
                                    Console.WriteLine("Item deleted.");
                                }
                                
                                break;
                            case ('R'):
                                Console.WriteLine("Enter Id of Reminder to Delete");
                                response = Console.ReadLine();
                                if (int.TryParse(response, out toDelete))
                                {
                                    reminderRepository.Delete(reminderRepository.FindById(toDelete));
                                    Console.WriteLine("Item deleted.");
                                }
                                break;
                            case ('M'):
                                Console.WriteLine("Enter Id of Meeting to Delete");
                                response = Console.ReadLine();
                                if (int.TryParse(response, out toDelete))
                                {
                                    meetingRepository.Delete(meetingRepository.FindById(toDelete));
                                    Console.WriteLine("Item deleted.");
                                }
                                break;
                        }

                        break;
					default:
						Console.WriteLine($"Invalid Option {selectedOption}, press any key to continue.");
						Console.Read();
						break;
				}
			}
			File.WriteAllText("Reminders.json", reminderRepository.ToJson());
            File.WriteAllText("Appointments.json", appointmentRepository.ToJson());
            File.WriteAllText("Meetings.json", meetingRepository.ToJson());
        }
	}
}
