

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataJuggler.Speech
{

    #region class Scene
    /// <summary>
    /// This class [Enter Class Description]
    /// </summary>
    public class Scene
    {
        
        #region Private Variables
        private List<Dialog> dialogs;
        private string imageUrl;
        private string name;
        private string fileName;
        #endregion

        #region Properties

            #region Dialogs
            /// <summary>
            /// This property gets or sets the value for 'Dialogs'.
            /// </summary>
            public List<Dialog> Dialogs
            {
                get { return dialogs; }
                set { dialogs = value; }
            }
            #endregion
            
            #region FileName
            /// <summary>
            /// This property gets or sets the value for 'FileName'.
            /// </summary>
            public string FileName
            {
                get { return fileName; }
                set { fileName = value; }
            }
            #endregion
            
            #region HasDialogs
            /// <summary>
            /// This property returns true if this object has a 'Dialogs'.
            /// </summary>
            public bool HasDialogs
            {
                get
                {
                    // initial value
                    bool hasDialogs = (this.Dialogs != null);
                    
                    // return value
                    return hasDialogs;
                }
            }
            #endregion
            
            #region ImageUrl
            /// <summary>
            /// This property gets or sets the value for 'ImageUrl'.
            /// </summary>
            public string ImageUrl
            {
                get { return imageUrl; }
                set { imageUrl = value; }
            }
            #endregion
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for 'Name'.
            /// </summary>
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
