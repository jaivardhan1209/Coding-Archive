using System;
using System.Collections.Generic;

namespace Codepractice.CSharpLibrary
{
    public interface ElevetorInterface
    {
        void Open();

        void Close();

        void Move(bool direction);

        int MaxFloor { get; set; }

        int MinFloor { get; set; }

        int speed { get; set; }

    }

    public abstract class Elevator
    {
        public string Manifecturer { get; set; }

        public string Name;

        public abstract void Load(int numberofPassanger);

    }

    public class ServiceElevator : Elevator, ElevetorInterface
    {
        public int MaxFloor
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int MinFloor
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int speed
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public override void Load(int numberofPassanger)
        {
            throw new NotImplementedException();
        }

        public void Move(bool direction)
        {
            throw new NotImplementedException();
        }

        public void Open()
        {
            throw new NotImplementedException();
        }
    }

    public class ElevetorManager
    {
       public List<ServiceElevator> elevetors { get; set; }
    
    }
}
