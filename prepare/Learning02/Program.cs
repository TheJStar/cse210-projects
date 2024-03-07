using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        Job job2 = new Job();
        Job job3 = new Job();
        Job job4 = new Job();

        Resume resume1 = new Resume();
        Resume resume2 = new Resume();

        job1._jobTitle = "Software Engieneer";
        job2._jobTitle = "Janater";
        job3._jobTitle = "Football Player";
        job4._jobTitle = "Teacher";

        job1.DisplayJobTitle();
        job2.DisplayJobTitle();
        job3.DisplayJobTitle();
        job4.DisplayJobTitle();

        resume1._name = "Bobby Smith";
        resume1._jobList.Add(job1);
        resume1._jobList.Add(job3);

        resume2._name = "Rick Hacker";
        resume2._jobList.Add(job2);
        resume2._jobList.Add(job4);

        resume1.DisplayJobs();
        resume2.DisplayJobs();
    }
}