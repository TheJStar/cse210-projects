public class Resume {
    public string _name;
    public List<Job> _jobList = new List<Job>();

    public void DisplayJobs() {
        Console.WriteLine(_name+":");

        _jobList.ForEach(job => {
            Console.WriteLine(job._jobTitle);
        });
    }
}