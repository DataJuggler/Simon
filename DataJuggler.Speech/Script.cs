

#region using statements


#endregion

namespace DataJuggler.Speech
{

    #region class Script
    /// <summary>
    /// This class is the top level object in a collection of scenes.
    /// </summary>
    public class Script
    {
        
        #region Private Variables
        private List<Scene> scenes;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'Script' object.
        /// </summary>
        public Script()
        {
            // Create a new collection of 'Scene' objects.
            Scenes = new List<Scene>();
        }
        #endregion
        
        #region Properties
            
            #region Scenes
            /// <summary>
            /// This property gets or sets the value for 'Scenes'.
            /// </summary>
            public List<Scene> Scenes
            {
                get { return scenes; }
                set { scenes = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
