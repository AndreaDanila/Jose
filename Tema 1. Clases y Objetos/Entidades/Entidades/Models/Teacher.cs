using Entidades.DAL;
using System;

namespace Entidades.Models
{
    public class Teacher : User
    {
        public string DNI { get; set; }

        public Guid PupilId { get; set; }

        public Student Pupil { get; set; }

        public bool AssignPupil(Guid pupilId)
        {
            if (StudentsRepository.Items.ContainsKey(pupilId))
            {
                PupilId = pupilId;
                Pupil = StudentsRepository.Items[pupilId];
                return true;
            }
            else
            {
                Console.WriteLine($"no existe un estudiante con este id:{pupilId}");
                return false;
            }
        }
    }
}
