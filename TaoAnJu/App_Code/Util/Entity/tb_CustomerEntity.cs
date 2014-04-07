using System;

namespace TaoAnJu.Util
{
    public class tb_CustomerEntity
    {
        private Int32 _int_CId = 0;
        private bool _int_CIdNull = true;
        private string _vc_Name;
        private string _vc_Mobile;
        private Int32 _int_Age = 0;
        private bool _int_AgeNull = true;
        private string _vc_Occupation;
        private string _vc_WorkingPlace;
        private string _vc_LivePlace;
        private string _vc_Use;
        private decimal _dec_Price = 0;
        private bool _dec_PriceNull = true;
        private decimal _dec_TotalPrice = 0;
        private bool _dec_TotalPriceNull = true;
        private string _vc_Referee;
        private Int32 _int_UserId = 0;
        private bool _int_UserIdNull = true;
        private DateTime _dt_CreateDate;
        private bool _dt_CreateDateNull = true;
        private string _vc_Static;

        public tb_CustomerEntity() { }
        /// <summary>
        /// ���� <c>�ͻ����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_CId</c>�ֶε�ֵ</value>
        public Int32 int_CId
        {
            get { return _int_CId; }
            set
            {
                _int_CIdNull = false;
                _int_CId = value;
            }
        }
        /// <summary>
        /// ���� <c>�ͻ�����Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_CIdNull</c>�ֶε�ֵ</value>
        public bool int_CIdNull
        {
            get { return _int_CIdNull; }
            set { _int_CIdNull = value; }
        }
        /// <summary>
        /// ���� <c>����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Name</c>�ֶε�ֵ</value>
        public string vc_Name
        {
            get { return _vc_Name; }
            set { _vc_Name = value; }
        }
        /// <summary>
        /// ���� <c>�ֻ���</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Mobile</c>�ֶε�ֵ</value>
        public string vc_Mobile
        {
            get { return _vc_Mobile; }
            set { _vc_Mobile = value; }
        }
        /// <summary>
        /// ���� <c>����</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_Age</c>�ֶε�ֵ</value>
        public Int32 int_Age
        {
            get { return _int_Age; }
            set
            {
                _int_AgeNull = false;
                _int_Age = value;
            }
        }
        /// <summary>
        /// ���� <c>�����Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_AgeNull</c>�ֶε�ֵ</value>
        public bool int_AgeNull
        {
            get { return _int_AgeNull; }
            set { _int_AgeNull = value; }
        }
        /// <summary>
        /// ���� <c>ְҵ</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Occupation</c>�ֶε�ֵ</value>
        public string vc_Occupation
        {
            get { return _vc_Occupation; }
            set { _vc_Occupation = value; }
        }
        /// <summary>
        /// ���� <c>�����ص�</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_WorkingPlace</c>�ֶε�ֵ</value>
        public string vc_WorkingPlace
        {
            get { return _vc_WorkingPlace; }
            set { _vc_WorkingPlace = value; }
        }
        /// <summary>
        /// ���� <c>��ס�ص�</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_LivePlace</c>�ֶε�ֵ</value>
        public string vc_LivePlace
        {
            get { return _vc_LivePlace; }
            set { _vc_LivePlace = value; }
        }
        /// <summary>
        /// ���� <c>����ʹ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Use</c>�ֶε�ֵ</value>
        public string vc_Use
        {
            get { return _vc_Use; }
            set { _vc_Use = value; }
        }
        /// <summary>
        /// ���� <c>��������</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dec_Price</c>�ֶε�ֵ</value>
        public decimal dec_Price
        {
            get { return _dec_Price; }
            set
            {
                _dec_PriceNull = false;
                _dec_Price = value;
            }
        }
        /// <summary>
        /// ���� <c>���������Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dec_PriceNull</c>�ֶε�ֵ</value>
        public bool dec_PriceNull
        {
            get { return _dec_PriceNull; }
            set { _dec_PriceNull = value; }
        }
        /// <summary>
        /// ���� <c>�����ܼ�</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dec_TotalPrice</c>�ֶε�ֵ</value>
        public decimal dec_TotalPrice
        {
            get { return _dec_TotalPrice; }
            set
            {
                _dec_TotalPriceNull = false;
                _dec_TotalPrice = value;
            }
        }
        /// <summary>
        /// ���� <c>�����ܼ��Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dec_TotalPriceNull</c>�ֶε�ֵ</value>
        public bool dec_TotalPriceNull
        {
            get { return _dec_TotalPriceNull; }
            set { _dec_TotalPriceNull = value; }
        }
        /// <summary>
        /// ���� <c>�Ƽ���</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Referee</c>�ֶε�ֵ</value>
        public string vc_Referee
        {
            get { return _vc_Referee; }
            set { _vc_Referee = value; }
        }
        /// <summary>
        /// ���� <c>���Ĺܼ�</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_UserId</c>�ֶε�ֵ</value>
        public Int32 int_UserId
        {
            get { return _int_UserId; }
            set
            {
                _int_UserIdNull = false;
                _int_UserId = value;
            }
        }
        /// <summary>
        /// ���� <c>���Ĺܼ��Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>int_UserIdNull</c>�ֶε�ֵ</value>
        public bool int_UserIdNull
        {
            get { return _int_UserIdNull; }
            set { _int_UserIdNull = value; }
        }
        /// <summary>
        /// ���� <c>����ʱ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dt_CreateDate</c>�ֶε�ֵ</value>
        public DateTime dt_CreateDate
        {
            get { return _dt_CreateDate; }
            set
            {
                _dt_CreateDateNull = false;
                _dt_CreateDate = value;
            }
        }
        /// <summary>
        /// ���� <c>����ʱ���Ƿ�Ϊ��</c>.
        /// </summary>
        /// <value>��Ӧ����<c>dt_CreateDateNull</c>�ֶε�ֵ</value>
        public bool dt_CreateDateNull
        {
            get { return _dt_CreateDateNull; }
            set { _dt_CreateDateNull = value; }
        }
        /// <summary>
        /// ���� <c>״̬</c>.
        /// </summary>
        /// <value>��Ӧ����<c>vc_Static</c>�ֶε�ֵ</value>
        public string vc_Static
        {
            get { return _vc_Static; }
            set { _vc_Static = value; }
        }

    }//�ඨ�����
}//�����ռ����

