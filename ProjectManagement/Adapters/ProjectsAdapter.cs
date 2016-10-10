using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ProjectManagement.Adapters
{
    class ProjectsAdapter : BaseAdapter<Projects>
    {
        #region Variables
        private Context context;
        private List<Projects> ProjectList;

        #endregion

        public ProjectsAdapter(Context context, List<Projects> projectList)
        {
            this.context = context;
            this.ProjectList = projectList;
        }

        #region Overrides
        public override Projects this[int position]
        {
            get { return ProjectList[position]; }
        }
        public override int Count
        {
            get { return ProjectList.Count; }
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            LinearLayout view = (LinearLayout)convertView;
            if (view == null)
                view = (LinearLayout)LayoutInflater.FromContext(context).Inflate(Resource.Layout.list_Item, null);

            TextView txtProjectName = view.FindViewById<TextView>(Resource.Id.txt_ProjectListitem_Name);
            txtProjectName.Text = ProjectList[position].ProjectName;

            return view;
        }
        #endregion








    }
}