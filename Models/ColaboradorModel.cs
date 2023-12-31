﻿/*
 * @file ColaboradorModel.cs
 * @author Marcos Vasconcelos (a18568@alunos.ipca.pt)
 * @author Diogo Oliveira (a20468@alunos.ipca.pt)
 * @brief Classe ColaboradorModel para representar um colaborador com propriedades para o identificador
 * @date dezembro 2023
 * 
 * @copyright Copyright (c) 2023
 * 
 */

namespace Models
{
    [Serializable]
    public class Colaborador : Utilizador
    {
        #region Attributes

        private int idColaborador;

        #endregion

        #region Constructor

        /// <summary>
        /// Construtor de um Cliente ao receber parâmetros
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="morada"></param>
        /// <param name="telemovel"></param>
        /// <param name="dataNascimento"></param>
        public Colaborador(int id, string nome, string morada, string telemovel, DateTime dataNascimento)
            : base(nome, morada, telemovel, dataNascimento)
        {
            idColaborador = id;
        }

        #endregion

        #region Methods

        #region Properties

        /// <summary>
        /// Propriedade para manipular o id do colaborador
        /// </summary>
        public int IdColaborador
        {
            get { return idColaborador; }
            set { idColaborador = value; }
        }

        #endregion

        #region Other Methods
        #endregion

        #region Destructor

        /// <summary>
        /// Destrutor por defeito
        /// </summary>
        ~Colaborador() { }
        #endregion

        #endregion
    }
}
