namespace exchange_cli
{
    public class Exchange
    {
        public Motd motd { get; set; }
        public bool success { get; set; }
        public string _base { get; set; }
        public string date { get; set; }
        public Info info { get; set; }
        public Rates rates { get; set; }
        public Query query { get; set; }
        public float? result { get; set; }
    }

    public class Motd
    {
        public string msg { get; set; }
        public string url { get; set; }
    }

    public class Query
    {
        public string from { get; set; }
        public string to { get; set; }
        public float amount { get; set; }
    }

    public class Info
    {
        public float? rate { get; set; }
    }

    public class Rates
    {
        public float AED { get; set; }
        public float AFN { get; set; }
        public float ALL { get; set; }
        public float AMD { get; set; }
        public float ANG { get; set; }
        public float AOA { get; set; }
        public float ARS { get; set; }
        public float AUD { get; set; }
        public float AWG { get; set; }
        public float AZN { get; set; }
        public float BAM { get; set; }
        public float BBD { get; set; }
        public float BDT { get; set; }
        public float BGN { get; set; }
        public float BHD { get; set; }
        public float BIF { get; set; }
        public float BMD { get; set; }
        public float BND { get; set; }
        public float BOB { get; set; }
        public float BRL { get; set; }
        public float BSD { get; set; }
        public float BTC { get; set; }
        public float BTN { get; set; }
        public float BWP { get; set; }
        public float BYN { get; set; }
        public float BZD { get; set; }
        public float CAD { get; set; }
        public float CDF { get; set; }
        public float CHF { get; set; }
        public float CLF { get; set; }
        public float CLP { get; set; }
        public float CNH { get; set; }
        public float CNY { get; set; }
        public float COP { get; set; }
        public float CRC { get; set; }
        public float CUC { get; set; }
        public float CUP { get; set; }
        public float CVE { get; set; }
        public float CZK { get; set; }
        public float DJF { get; set; }
        public float DKK { get; set; }
        public float DOP { get; set; }
        public float DZD { get; set; }
        public float EGP { get; set; }
        public float ERN { get; set; }
        public float ETB { get; set; }
        public float EUR { get; set; }
        public float FJD { get; set; }
        public float FKP { get; set; }
        public float GBP { get; set; }
        public float GEL { get; set; }
        public float GGP { get; set; }
        public float GHS { get; set; }
        public float GIP { get; set; }
        public float GMD { get; set; }
        public float GNF { get; set; }
        public float GTQ { get; set; }
        public float GYD { get; set; }
        public float HKD { get; set; }
        public float HNL { get; set; }
        public float HRK { get; set; }
        public float HTG { get; set; }
        public float HUF { get; set; }
        public float IDR { get; set; }
        public float ILS { get; set; }
        public float IMP { get; set; }
        public float INR { get; set; }
        public float IQD { get; set; }
        public float IRR { get; set; }
        public float ISK { get; set; }
        public float JEP { get; set; }
        public float JMD { get; set; }
        public float JOD { get; set; }
        public float JPY { get; set; }
        public float KES { get; set; }
        public float KGS { get; set; }
        public float KHR { get; set; }
        public float KMF { get; set; }
        public float KPW { get; set; }
        public float KRW { get; set; }
        public float KWD { get; set; }
        public float KYD { get; set; }
        public float KZT { get; set; }
        public float LAK { get; set; }
        public float LBP { get; set; }
        public float LKR { get; set; }
        public float LRD { get; set; }
        public float LSL { get; set; }
        public float LYD { get; set; }
        public float MAD { get; set; }
        public float MDL { get; set; }
        public float MGA { get; set; }
        public float MKD { get; set; }
        public float MMK { get; set; }
        public float MNT { get; set; }
        public float MOP { get; set; }
        public float MRU { get; set; }
        public float MUR { get; set; }
        public float MVR { get; set; }
        public float MWK { get; set; }
        public float MXN { get; set; }
        public float MYR { get; set; }
        public float MZN { get; set; }
        public float NAD { get; set; }
        public float NGN { get; set; }
        public float NIO { get; set; }
        public float NOK { get; set; }
        public float NPR { get; set; }
        public float NZD { get; set; }
        public float OMR { get; set; }
        public float PAB { get; set; }
        public float PEN { get; set; }
        public float PGK { get; set; }
        public float PHP { get; set; }
        public float PKR { get; set; }
        public float PLN { get; set; }
        public float PYG { get; set; }
        public float QAR { get; set; }
        public float RON { get; set; }
        public float RSD { get; set; }
        public float RUB { get; set; }
        public float RWF { get; set; }
        public float SAR { get; set; }
        public float SBD { get; set; }
        public float SCR { get; set; }
        public float SDG { get; set; }
        public float SEK { get; set; }
        public float SGD { get; set; }
        public float SHP { get; set; }
        public float SLL { get; set; }
        public float SOS { get; set; }
        public float SRD { get; set; }
        public float SSP { get; set; }
        public float STD { get; set; }
        public float STN { get; set; }
        public float SVC { get; set; }
        public float SYP { get; set; }
        public float SZL { get; set; }
        public float THB { get; set; }
        public float TJS { get; set; }
        public float TMT { get; set; }
        public float TND { get; set; }
        public float TOP { get; set; }
        public float TRY { get; set; }
        public float TTD { get; set; }
        public float TWD { get; set; }
        public float TZS { get; set; }
        public float UAH { get; set; }
        public float UGX { get; set; }
        public float USD { get; set; }
        public float UYU { get; set; }
        public float UZS { get; set; }
        public float VES { get; set; }
        public float VND { get; set; }
        public float VUV { get; set; }
        public float WST { get; set; }
        public float XAF { get; set; }
        public float XAG { get; set; }
        public float XAU { get; set; }
        public float XCD { get; set; }
        public float XDR { get; set; }
        public float XOF { get; set; }
        public float XPD { get; set; }
        public float XPF { get; set; }
        public float XPT { get; set; }
        public float YER { get; set; }
        public float ZAR { get; set; }
        public float ZMW { get; set; }
        public float ZWL { get; set; }
    }
}


