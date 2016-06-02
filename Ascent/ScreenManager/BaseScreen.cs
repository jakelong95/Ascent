using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    abstract class BaseScreen
    {
        public String name;
        public ScreenState state;
        public Single position;
        public bool focused;
        public bool grabFocus = true;

        public virtual void HandleInput()
        {

        }

        public virtual void Update(float delta)
        {

        }

        public virtual void Draw()
        {
            
        }

        public virtual void Unload()
        {
            state = ScreenState.Shutdown;
        }

    }
