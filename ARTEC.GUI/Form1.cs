﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARTEC.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Framework.Loyola.Usuario unUsuario = new Framework.Loyola.Usuario();
            unUsuario.NombreUsuario = "hola";
            MessageBox.Show("Test");
            MessageBox.Show(unUsuario.NombreUsuario);
            
            
        }
    }
}
