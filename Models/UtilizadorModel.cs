﻿/*
 * @file UtilizadorModel.cs
 * @author Marcos Vasconcelos (a18568@alunos.ipca.pt)
 * @author Diogo Oliveira (a20468@alunos.ipca.pt)
 * @brief Classe UtilizadorModel para representar um utilizador com propriedades para o nome, morada, telemóvel e data de nascimento
 * @date dezembro 2023
 * 
 * @copyright Copyright (c) 2023
 * 
 */

namespace Models
{
    [Serializable]
    public class Utilizador
    {
        #region Attributes

        private string nome;
        private string morada;
        private string telemovel;
        private DateTime dataNascimento;

        #endregion

        #region Methods

        #region Constructor

        /// <summary>
        /// Construtor de um Utilizador ao receber parâmetros
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="t"></param>
        /// <param name="dn"></param>
        public Utilizador(string n, string m, string t, DateTime dn)
        {
            nome = n;
            morada = m;
            telemovel = t;
            dataNascimento = dn;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Propriedade para manipular o nome do utilizador
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /// <summary>
        /// Propriedade para manipular a morada do utilizador
        /// </summary>
        public string Morada
        {
            get { return morada; }
            set { morada = value; }
        }

        /// <summary>
        /// Propriedade para manipular o telemóvel do utilizador
        /// </summary>
        public string Telemovel
        {
            get { return telemovel; }
            set { telemovel = value; }
        }

        /// <summary>
        /// Propriedade para manipular a data de nascimento do utilizador
        /// </summary>
        public DateTime DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }

        #endregion

        #region Other Methods
        #endregion

        #region Destructor

        /// <summary>
        /// Destrutor por defeito
        /// </summary>
        ~Utilizador()
        {
        }

        #endregion

        #endregion
    }
}
