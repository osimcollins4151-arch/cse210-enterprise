using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Resume / Jobs program");
        Console.WriteLine();

        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;

        Job job3 = new Job();
        job3._jobTitle = "Hardware Engineer";
        job3._company = "SkyDream ICT Unit";
        job3._startYear = 2025;
        job3._endYear = 2027;

        Resume myResume = new Resume();
        myResume._name = "Collins Osim";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume._jobs.Add(job3);

        myResume.Display();
    }
}