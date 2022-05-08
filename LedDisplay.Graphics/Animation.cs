using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LedDisplay.Graphics
{
    [Serializable]
    public class Animation : IList<AnimationFrame>
    {
        private List<AnimationFrame> frames;

        public int FrameDelay { get; set; }

        public int Count => frames.Count;

        public bool IsReadOnly => false;

        public AnimationFrame this[int index] 
        {
            get => frames[index];
            set => frames[index] = value;
        }

        public Animation()
        {
            frames = new List<AnimationFrame>();
            this.FrameDelay = 5;
        }

        public int IndexOf(AnimationFrame item)
        {
            return frames.IndexOf(item);
        }

        public void Insert(int index, AnimationFrame item)
        {
            frames.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            frames.RemoveAt(index);
        }

        public void Add(AnimationFrame item)
        {
            frames.Add(item);
        }

        public void Clear()
        {
            frames.Clear();
        }

        public bool Contains(AnimationFrame item)
        {
            return frames.Contains(item);
        }

        public void CopyTo(AnimationFrame[] array, int arrayIndex)
        {
            frames.CopyTo(array, arrayIndex);
        }

        public bool Remove(AnimationFrame item)
        {
            return frames.Remove(item);
        }

        public IEnumerator<AnimationFrame> GetEnumerator()
        {
            return frames.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return frames.GetEnumerator();
        }

        public void Save(string filename)
        {
            using (var stream = File.Create(filename))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Close();
            }
        }

        public static Animation Load(string filename)
        {
            using (var stream = File.OpenRead(filename))
            {
                var formatter = new BinaryFormatter();
                var result = (Animation)formatter.Deserialize(stream);
                stream.Close();

                return result;
            }
        }


    }
}
