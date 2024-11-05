﻿/*
 * Bluepay C#.NET Sample code.
 *
 * Updated: 2015-05-20
 *
 * This code is Free.  You may use it, modify it and redistribute it.
 * If you do make modifications that are useful, Bluepay would love it if you donated
 * them back to us!
 *
 *
 */
using System;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;
using System.Collections;

namespace BluePayLibrary
{
    /// <summary>
    /// This is the BluePay object.
    /// </summary>
    public class BluePay
    {
        // required for every transaction
        public string accountID = "";
        public string URL = "";
        public string secretKey = "";
        public string mode = "";
        public string api = "";

        // required for auth or sale
        public string paymentAccount = "";
        public string cvv2 = "";
        public string cardExpire = "";
        public Regex track1And2 = new Regex(@"(%B)\d{0,19}\^([\w\s]*)\/([\w\s]*)([\s]*)\^\d{7}\w*\?;\d{0,19}=\d{7}\w*\?");
        public Regex track2Only = new Regex(@";\d{0,19}=\d{7}\w*\?");
        public string swipeData = "";
        public string routingNum = "";
        public string accountNum = "";
        public string accountType = "";
        public string docType = "";
        public string name1 = "";
        public string name2 = "";
        public string addr1 = "";
        public string city = "";
        public string state = "";
        public string zip = "";

        // optional for auth or sale
        public string addr2 = "";
        public string phone = "";
        public string email = "";
        public string country = "";

        // transaction variables
        public string amount = "";
        public string transType = "";
        public string paymentType = "";
        public string masterID = "";
        public string rebillID = "";

        // rebill variables
        public string doRebill = "";
        public string rebillAmount = "";
        public string rebillFirstDate = "";
        public string rebillExpr = "";
        public string rebillCycles = "";
        public string rebillNextAmount = "";
        public string rebillNextDate = "";
        public string rebillStatus = "";
        public string templateID = "";

        // level2 variables
        public string customID1 = "";
        public string customID2 = "";
        public string invoiceID = "";
        public string orderID = "";
        public string amountTip = "";
        public string amountTax = "";
        public string amountFood = "";
        public string amountMisc = "";
        public string memo = "";

        // Generating Simple Hosted Payment Form URL fields
        public string dba = "";
        public string returnURL = "";
        public string discoverImage = "";
        public string amexImage = "";
        public string protectAmount = "";
        public string rebillProtect = "";
        public string protectCustomID1 = "";
        public string protectCustomID2 = "";
        public string shpfFormID = "";
        public string receiptFormID = "";
        public string remoteURL = "";
        public string cardTypes = "";
        public string receiptTpsDef = "";
        public string receiptTpsString = "";
        public string receiptTamperProofSeal = "";
        public string receiptURL = "";
        public string bp10emuTpsDef = "";
        public string bp10emuTpsString = "";
        public string bp10emuTamperProofSeal = "";
        public string shpfTpsDef = "";
        public string shpfTpsString = "";
        public string shpfTamperProofSeal = "";

        // rebill fields
        public string reportStartDate = "";
        public string reportEndDate = "";
        public string doNotEscape = "";
        public string queryBySettlement = "";
        public string queryByHierarchy = "";
        public string excludeErrors = "";

        public string response = "";
        public string TPS = "";
        public string BPheaderstring = "";

        public int numRetries = 0;

        public BluePay(string accountID, string secretKey, string mode)
        {
            this.accountID = accountID;
            this.secretKey = secretKey;
            this.mode = mode;
        }

        /// <summary>
        /// Sets Customer Information
        /// </summary>
        /// <param name="name1"></param>
        /// <param name="name2"></param>
        /// <param name="addr1"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <param name="country"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>

        public void SetCustomerInformation(string firstName, string lastName, string address1 = null, string address2 = null, string city = null, string state = null, string zip = null, string country = null, string phone = null, string email = null)
        {
            this.name1 = firstName;
            this.name2 = lastName;
            this.addr1 = address1;
            this.addr2 = address2;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.country = country;
            this.phone = phone;
            this.email = email;
        }

        /// <summary>
        /// Sets Credit Card Information
        /// </summary>
        /// <param name="ccNumber"></param>
        /// <param name="ccExpiration"></param>
        /// <param name="cvv2"></param>
        public void SetCCInformation(string ccNumber = null, string ccExpiration = null, string cvv2 = null)
        {
            this.paymentType = "CREDIT";
            this.paymentAccount = ccNumber;
            this.cardExpire = ccExpiration;
            this.cvv2 = cvv2;
        }

        /// <summary>
        /// Sets Swipe Information Using Either Both Track 1 2, Or Just Track 2
        /// </summary>
        /// <param name="swipe"></param> 
        public void Swipe(string swipe)
        {
            this.paymentType = "CREDIT";
            this.swipeData = swipe;
        }

        /// <summary>
        /// Sets ACH Information
        /// </summary>
        /// <param name="routingNum"></param>
        /// <param name="accountNum"></param>
        /// <param name="accountType"></param>
        /// <param name="docType"></param>
        public void SetACHInformation(string routingNum, string accountNum, string accountType, string docType = null)
        {
            this.paymentType = "ACH";
            this.routingNum = routingNum;
            this.accountNum = accountNum;
            this.accountType = accountType;
            this.docType = docType;
        }

        /// <summary>
        /// Sets Rebilling Cycle Information. To be used with other functions to create a transaction.
        /// </summary>
        /// <param name="rebAmount"></param>
        /// <param name="rebFirstDate"></param>
        /// <param name="rebExpr"></param>
        /// <param name="rebCycles"></param>
        public void SetRebillingInformation(string rebAmount, string rebFirstDate, string rebExpr, string rebCycles)
        {
            this.doRebill = "1";
            this.rebillFirstDate = rebFirstDate;
            this.rebillExpr = rebExpr;
            this.rebillCycles = rebCycles;
            this.rebillAmount = rebAmount;
        }

        /// <summary>
        /// Updates Rebilling Cycle
        /// </summary>
        /// <param name="rebillID"></param>
        /// <param name="rebNextDate"></param>
        /// <param name="rebExpr"></param>
        /// <param name="rebCycles"></param>
        /// <param name="rebAmount"></param>
        /// <param name="rebNextAmount"></param>
        /// <param name="templateID"></param>
        public void UpdateRebillingInformation(string rebillID, string rebNextDate, string rebExpr, string rebCycles, string rebAmount, string rebNextAmount, string templateID = null)
        {
            this.transType = "SET";
            this.api = "bp20rebadmin";
            this.rebillID = rebillID;
            this.rebillNextDate = rebNextDate;
            this.rebillExpr = rebExpr;
            this.rebillCycles = rebCycles;
            this.rebillAmount = rebAmount;
            this.rebillNextAmount = rebNextAmount;
            this.templateID = templateID;
        }

        /// <summary>
        /// Updates a rebilling cycle's payment information
        /// </summary>
        /// <param name="templateID"></param>
        public void UpdateRebillPaymentInformation(string templateID)
        {
            this.templateID = templateID;
        }

        /// <summary>
        /// Cancels Rebilling Cycle
        /// </summary>
        /// <param name="rebillID"></param>
        public void CancelRebilling(string rebillID)
        {
            this.transType = "SET";
            this.rebillStatus = "stopped";
            this.rebillID = rebillID;
            this.api = "bp20rebadmin";
        }

        /// <summary>
        /// Gets a existing rebilling cycle's status
        /// </summary>
        /// <param name="rebillID"></param>
        public void GetRebillStatus(string rebillID)
        {
            this.transType = "GET";
            this.rebillID = rebillID;
            this.api = "bp20rebadmin";
        }

        /// <summary>
        /// Gets Report of Transaction Data
        /// </summary>
        /// <param name="reportStart"></param>
        /// <param name="reportEnd"></param>
        /// <param name="subaccountsSearched"></param>
        /// <param name="doNotEscape"></param>
        /// <param name="errors"></param>
        public void GetTransactionReport(string reportStartDate, string reportEndDate, string subaccountsSearched,
                string doNotEscape = null, string excludeErrors = null)
        {
            this.queryBySettlement = "0";
            this.reportStartDate = reportStartDate;
            this.reportEndDate = reportEndDate;
            this.queryByHierarchy = subaccountsSearched;
            this.doNotEscape = doNotEscape;
            this.excludeErrors = excludeErrors;
            this.api = "bpdailyreport2";
        }

        /// <summary>
        /// Gets Report of Settled Transaction Data
        /// </summary>
        /// <param name="reportStart"></param>
        /// <param name="reportEnd"></param>
        /// <param name="subaccountsSearched"></param>
        /// <param name="doNotEscape"></param>
        /// <param name="errors"></param>
        public void GetTransactionSettledReport(string reportStartDate, string reportEndDate, string subaccountsSearched,
                string doNotEscape = null, string excludeErrors = null)
        {
            this.queryBySettlement = "1";
            this.reportStartDate = reportStartDate;
            this.reportEndDate = reportEndDate;
            this.queryByHierarchy = subaccountsSearched;
            this.doNotEscape = doNotEscape;
            this.excludeErrors = excludeErrors;
            this.api = "bpdailyreport2";
        }

        /// <summary>
        /// Gets Details of a Transaction
        /// </summary>
        /// <param name="reportStart"></param>
        /// <param name="reportEnd"></param>
        /// <param name="errors"></param>
        public void GetSingleTransQuery(string transactionID, string reportStartDate, string reportEndDate, string errors = null)
        {
            this.reportStartDate = reportStartDate;
            this.reportEndDate = reportEndDate;
            this.excludeErrors = errors;
            this.masterID = transactionID;
            this.api = "stq";
        }

        /// <summary>
        /// Queries by Transaction ID. To be used with getSingleTransQuery
        /// </summary>
        /// <param name="transID"></param>
        public void QueryByTransactionID(string transID)
        {
            this.masterID = transID;
        }

        /// <summary>
        /// Queries by Payment Type. To be used with getSingleTransQuery
        /// </summary>
        /// <param name="payType"></param>
        public void QueryByPaymentType(string payType)
        {
            this.paymentType = payType;
        }

        /// <summary>
        /// Queries by Transaction Type. To be used with getSingleTransQuery
        /// </summary>
        /// <param name="transType"></param>
        public void QueryBytransType(string transType)
        {
            this.transType = transType;
        }

        /// <summary>
        /// Queries by Transaction Amount. To be used with getSingleTransQuery
        /// </summary>
        /// <param name="amount"></param>
        public void QueryByAmount(string amount)
        {
            this.amount = amount;
        }

        /// <summary>
        /// Queries by First Name (NAME1) . To be used with getSingleTransQuery
        /// </summary>
        /// <param name="name1"></param>
        public void QueryByName1(string name1)
        {
            this.name1 = name1;
        }

        /// <summary>
        /// Queries by Last Name (NAME2) . To be used with getSingleTransQuery
        /// </summary>
        /// <param name="name2"></param>
        public void QueryByName2(string name2)
        {
            this.name2 = name2;
        }

        /// <summary>
        /// Runs a Sale Transaction
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="masterID"></param>
        public void Sale(string amount, string masterID = null)
        {
            this.transType = "SALE";
            this.api = "bp10emu";
            this.amount = amount;
            this.masterID = masterID;
        }

        /// <summary>
        /// Runs an Auth Transaction
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="masterID"></param>

        public void Auth(string amount, string masterID = null)
        {
            this.transType = "AUTH";
            this.api = "bp10emu";
            this.amount = amount;
            this.masterID = masterID;
        }

        /// <summary>
        /// Runs a Refund Transaction
        /// </summary>
        /// <param name="masterID"></param>
        /// <param name="amount"></param>

        public void Refund(string masterID, string amount = null)
        {
            this.transType = "REFUND";
            this.api = "bp10emu";
            this.masterID = masterID;
            this.amount = amount;
        }

        /// <summary>
        /// Voids a transaction
        /// </summary>
        /// <param name="masterID"></param>

        public void Void(string masterID)
        {
            this.transType = "VOID";
            this.api = "bp10emu";
            this.masterID = masterID;
        }

        /// <summary>
        /// Runs a Capture Transaction
        /// </summary>
        /// <param name="masterID"></param>
        /// <param name="amount"></param>
        public void Capture(string masterID, string amount = null)
        {
            this.transType = "CAPTURE";
            this.masterID = masterID;
            this.amount = amount;
            this.api = "bp10emu";
        }

        /// <summary>
        /// Sets Custom ID Field
        /// </summary>
        /// <param name="customID1"></param>
        public void SetCustomID1(string customID1)
        {
            this.customID1 = customID1;
        }

        /// <summary>
        /// Sets Custom ID2 Field
        /// </summary>
        /// <param name="customID2"></param>
        public void SetCustomID2(string customID2)
        {
            this.customID2 = customID2;
        }

        /// <summary>
        /// Sets Invoice ID Field
        /// </summary>
        /// <param name="invoiceID"></param>
        public void SetInvoiceID(string invoiceID)
        {
            this.invoiceID = invoiceID;
        }

        /// <summary>
        /// Sets Order ID Field
        /// </summary>
        /// <param name="orderID"></param>
        public void SetOrderID(string orderID)
        {
            this.orderID = orderID;
        }

        /// <summary>
        /// Sets Amount Tip Field
        /// </summary>
        /// <param name="amountTip"></param>
        public void SetAmountTip(string amountTip)
        {
            this.amountTip = amountTip;
        }

        /// <summary>
        /// Sets Amount Tax Field
        /// </summary>
        /// <param name="amountTax"></param>
        public void SetAmountTax(string amountTax)
        {
            this.amountTax = amountTax;
        }

        /// <summary>
        /// Sets Amount Food Field
        /// </summary>
        /// <param name="amountFood"></param>
        public void SetAmountFood(string amountFood)
        {
            this.amountFood = amountFood;
        }

        /// <summary>
        /// Sets Amount Misc Field
        /// </summary>
        /// <param name="amountMisc"></param>
        public void SetAmountMisc(string amountMisc)
        {
            this.amountMisc = amountMisc;
        }

        /// <summary>
        /// Sets Memo Field
        /// </summary>
        /// <param name="memo"></param>
        public void SetMemo(string memo)
        {
            this.memo = memo;
        }

        /// <summary>
        /// Sets Phone Field
        /// </summary>
        /// <param name="Phone"></param>
        public void SetPhone(string Phone)
        {
            this.phone = Phone;
        }

        /// <summary>
        /// Sets Email Field
        /// </summary>
        /// <param name="Email"></param>
        public void SetEmail(string Email)
        {
            this.email = Email;
        }

        public void SetParam(string Name, string Value)
        {
            Name = Value;
        }

        /// <summary>
        /// Calculates TAMPER_PROOF_SEAL for bp20post API
        /// </summary>
        public void CalcTPS()
        {
            string tamper_proof_seal = this.secretKey
                                    + this.accountID
                                    + this.transType
                                    + this.amount
                                    + this.doRebill
                                    + this.rebillFirstDate
                                    + this.rebillExpr
                                    + this.rebillCycles
                                    + this.rebillAmount
                                    + this.masterID
                                    + this.mode;
            SHA512 sha512 = new SHA512CryptoServiceProvider();
            byte[] hash;
            ASCIIEncoding encode = new ASCIIEncoding();

            byte[] buffer = encode.GetBytes(tamper_proof_seal);
            hash = sha512.ComputeHash(buffer);
            this.TPS = ByteArrayToString(hash);
        }

        /// <summary>
        /// Calculates TAMPER_PROOF_SEAL for bp20rebadmin API
        /// </summary>
        public void CalcRebillTPS()
        {
            string tamper_proof_seal = this.secretKey +
                                 this.accountID +
                                 this.transType +
                                 this.rebillID;

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hash;
            ASCIIEncoding encode = new ASCIIEncoding();

            byte[] buffer = encode.GetBytes(tamper_proof_seal);
            hash = md5.ComputeHash(buffer);
            this.TPS = ByteArrayToString(hash);
        }

        /// <summary>
        /// Calculates TAMPER_PROOF_SEAL for bpdailyreport2 and stq APIs
        /// </summary>
        public void CalcReportTPS()
        {
            string tamper_proof_seal = this.secretKey + this.accountID + this.reportStartDate + this.reportEndDate;
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hash;
            ASCIIEncoding encode = new ASCIIEncoding();

            byte[] buffer = encode.GetBytes(tamper_proof_seal);
            hash = md5.ComputeHash(buffer);
            this.TPS = ByteArrayToString(hash);
        }

        /// <summary>
        /// Calculates BP_STAMP for trans notify post API
        /// </summary>
        /// <param name="secretKey"></param>
        /// <param name="transID"></param>
        /// <param name="transStatus"></param>
        /// <param name="transType"></param>
        /// <param name="amount"></param>
        /// <param name="batchID"></param>
        /// <param name="batchStatus"></param>
        /// <param name="totalCount"></param>
        /// <param name="totalAmount"></param>
        /// <param name="batchUploadID"></param>
        /// <param name="rebillID"></param>
        /// <param name="rebillAmount"></param>
        /// <param name="rebillStatus"></param>
        /// <returns></returns>
        public static string CalcTransNotifyTPS(string secretKey, string transID, string transStatus, string transType,
            string amount, string batchID, string batchStatus, string totalCount, string totalAmount,
            string batchUploadID, string rebillID, string rebillAmount, string rebillStatus)
        {
            string tamper_proof_seal = secretKey + transID + transStatus + transType + amount + batchID + batchStatus +
            totalCount + totalAmount + batchUploadID + rebillID + rebillAmount + rebillStatus;
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hash;
            ASCIIEncoding encode = new ASCIIEncoding();

            byte[] buffer = encode.GetBytes(tamper_proof_seal);
            hash = md5.ComputeHash(buffer);
            tamper_proof_seal = ByteArrayToString(hash);
            return tamper_proof_seal;
        }

        //This is used to convert a byte array to a hex string
        static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }

        /// <summary>
        /// Calls the methods necessary to generate a SHPF URL
        /// Required arguments for generate_url:
        /// merchantName: Merchant name that will be displayed in the payment page.
        /// returnURL: Link to be displayed on the transacton results page. Usually the merchant's web site home page.
        /// transactionType: SALE/AUTH -- Whether the customer should be charged or only check for enough credit available.
        /// acceptDiscover: Yes/No -- Yes for most US merchants. No for most Canadian merchants.
        /// acceptAmex: Yes/No -- Has an American Express merchant account been set up?
        /// amount: The amount if the merchant is setting the initial amount.
        /// protectAmount: Yes/No -- Should the amount be protected from changes by the tamperproof seal?
        /// rebilling: Yes/No -- Should a recurring transaction be set up?
        /// paymentTemplate: Select one of our payment form template IDs or your own customized template ID. If the customer should not be allowed to change the amount, add a 'D' to the end of the template ID. Example: 'mobileform01D'
        /// mobileform01 -- Credit Card Only - White Vertical (mobile capable) 
        /// default1v5 -- Credit Card Only - Gray Horizontal 
        /// default7v5 -- Credit Card Only - Gray Horizontal Donation
        /// default7v5R -- Credit Card Only - Gray Horizontal Donation with Recurring
        /// default3v4 -- Credit Card Only - Blue Vertical with card swipe
        /// mobileform02 -- Credit Card & ACH - White Vertical (mobile capable)
        /// default8v5 -- Credit Card & ACH - Gray Horizontal Donation
        /// default8v5R -- Credit Card & ACH - Gray Horizontal Donation with Recurring
        /// mobileform03 -- ACH Only - White Vertical (mobile capable)
        /// receiptTemplate: Select one of our receipt form template IDs, your own customized template ID, or "remote_url" if you have one.
        /// mobileresult01 -- Default without signature line - White Responsive (mobile)
        /// defaultres1 -- Default without signature line â€“ Blue
        /// V5results -- Default without signature line â€“ Gray
        /// V5Iresults -- Default without signature line â€“ White
        /// defaultres2 -- Default with signature line â€“ Blue
        /// remote_url - Use a remote URL
        /// receiptTempRemoteURL: Your remote URL ** Only required if receipt_template = "remote_url".

        /// Optional arguments for generate_url:
        /// rebProtect: Yes/No -- Should the rebilling fields be protected by the tamperproof seal?
        /// rebAmount: Amount that will be charged when a recurring transaction occurs.
        /// rebCycles: Number of times that the recurring transaction should occur. Not set if recurring transactions should continue until canceled.
        /// rebStartDate: Date (yyyy-mm-dd) or period (x units) until the first recurring transaction should occur. Possible units are DAY, DAYS, WEEK, WEEKS, MONTH, MONTHS, YEAR or YEARS. (ex. 2016-04-01 or 1 MONTH)
        /// rebFrequency: How often the recurring transaction should occur. Format is 'X UNITS'. Possible units are DAY, DAYS, WEEK, WEEKS, MONTH, MONTHS, YEAR or YEARS. (ex. 1 MONTH) 
        /// customID1: A merchant defined custom ID value.
        /// protectCustomID1: Yes/No -- Should the Custom ID value be protected from change using the tamperproof seal?
        /// customID2: A merchant defined custom ID 2 value.
        /// protectCustomID2: Yes/No -- Should the Custom ID 2 value be protected from change using the tamperproof seal?
        /// </summary>
        /// <param name="merchantName"></param>
        /// <param name="returnURL"></param>
        /// <param name="transactionType"></param>
        /// <param name="acceptDiscover"></param>
        /// <param name="acceptAmex"></param>
        /// <param name="amount"></param>
        /// <param name="protectAmount"></param>
        /// <param name="rebilling"></param>
        /// <param name="rebProtect"></param>
        /// <param name="rebAmount"></param>
        /// <param name="rebCycles"></param>
        /// <param name="rebStartDate"></param>
        /// <param name="rebFrequency"></param>
        /// <param name="customID1"></param>
        /// <param name="protectCustomID1"></param>
        /// <param name="customID2"></param>
        /// <param name="protectCustomID2"></param>
        /// <param name="paymentTemplate"></param>
        /// <param name="receiptTemplate"></param>
        /// <param name="receiptTempRemoteURL"></param>

        public string GenerateURL(string merchantName, string returnURL, string transactionType, string acceptDiscover, string acceptAmex, string amount = null, string protectAmount = "No", string rebilling = "No", string rebProtect = "Yes", string rebAmount = null, string rebCycles = null, string rebStartDate = null, string rebFrequency = null, string customID1 = null, string protectCustomID1 = "No", string customID2 = null, string protectCustomID2 = "No", string paymentTemplate = "mobileform01", string receiptTemplate = "mobileresult01", string receiptTempRemoteURL = null)
        {
            this.dba = merchantName;
            this.returnURL = returnURL;
            this.transType = transactionType;
            this.discoverImage = acceptDiscover.ToUpper()[0] == 'Y' ? "discvr.gif" : "spacer.gif";
            this.amexImage = acceptAmex.ToUpper()[0] == 'Y' ? "amex.gif" : "spacer.gif";
            this.amount = amount;
            this.protectAmount = protectAmount;
            this.doRebill = rebilling.ToUpper()[0] == 'Y' ? "1" : "0";
            this.rebillProtect = rebProtect;
            this.rebillAmount = rebAmount;
            this.rebillCycles = rebCycles;
            this.rebillFirstDate = rebStartDate;
            this.rebillExpr = rebFrequency;
            this.customID1 = customID1;
            this.protectCustomID1 = protectCustomID1;
            this.customID2 = customID2;
            this.protectCustomID2 = protectCustomID2;
            this.shpfFormID = paymentTemplate;
            this.receiptFormID = receiptTemplate;
            this.remoteURL = receiptTempRemoteURL;
            this.cardTypes = SetCardTypes();
            this.receiptTpsDef = "SHPF_ACCOUNT_ID SHPF_FORM_ID RETURN_URL DBA AMEX_IMAGE DISCOVER_IMAGE SHPF_TPS_DEF";
            this.receiptTpsString = SetReceiptTpsString();
            this.receiptTamperProofSeal = CalcURLTps(receiptTpsString);
            this.receiptURL = SetReceiptURL();
            this.bp10emuTpsDef = AddDefProtectedStatus("MERCHANT APPROVED_URL DECLINED_URL MISSING_URL MODE TRANSACTION_TYPE TPS_DEF");
            this.bp10emuTpsString = SetBp10emuTpsString();
            this.bp10emuTamperProofSeal = CalcURLTps(bp10emuTpsString);
            this.shpfTpsDef = AddDefProtectedStatus("SHPF_FORM_ID SHPF_ACCOUNT_ID DBA TAMPER_PROOF_SEAL AMEX_IMAGE DISCOVER_IMAGE TPS_DEF SHPF_TPS_DEF");
            this.shpfTpsString = SetShpfTpsString();
            this.shpfTamperProofSeal = CalcURLTps(shpfTpsString);
            return CalcURLResponse();
        }

        /// <summary>
        /// Sets the types of credit card images to use on the Simple Hosted Payment Form. Must be used with GenerateURL.
        /// </summary>
        public string SetCardTypes()
        {
            string creditCards = "vi-mc";
            creditCards = discoverImage == "discvr.gif" ? (creditCards + "-di") : creditCards;
            creditCards = amexImage == "amex.gif" ? (creditCards + "-am") : creditCards;
            return creditCards;
        }

        /// <summary>
        /// Sets the receipt Tamperproof Seal string. Must be used with GenerateURL.
        /// </summary>
        public string SetReceiptTpsString()
        {
            return secretKey + accountID + receiptFormID + returnURL + dba + amexImage + discoverImage + receiptTpsDef;
        }

        /// <summary>
        /// Sets the bp10emu string that will be used to create a Tamperproof Seal. Must be used with GenerateURL.
        /// </summary>
        public string SetBp10emuTpsString()
        {
            string bp10emu = secretKey + accountID + receiptURL + receiptURL + receiptURL + mode + transType + bp10emuTpsDef;
            return AddStringProtectedStatus(bp10emu);
        }

        /// <summary>
        /// Sets the Simple Hosted Payment Form string that will be used to create a Tamperproof Seal. Must be used with GenerateURL.
        /// </summary>
        public string SetShpfTpsString()
        {
            string shpf = secretKey + shpfFormID + accountID + dba + bp10emuTamperProofSeal + amexImage + discoverImage + bp10emuTpsDef + shpfTpsDef;
            return AddStringProtectedStatus(shpf);
        }

        /// <summary>
        /// Sets the receipt url or uses the remote url provided. Must be used with GenerateURL.
        /// </summary>
        public string SetReceiptURL()
        {
            string output = "";
            if (receiptFormID == "remote_url")
                output = remoteURL;
            else
            {
                output = "https://secure.bluepay.com/interfaces/shpf?SHPF_FORM_ID=" + receiptFormID +
                "&SHPF_ACCOUNT_ID=" + accountID +
                "&SHPF_TPS_DEF=" + EncodeURL(receiptTpsDef) +
                "&SHPF_TPS=" + EncodeURL(receiptTamperProofSeal) +
                "&RETURN_URL=" + EncodeURL(returnURL) +
                "&DBA=" + EncodeURL(dba) +
                "&AMEX_IMAGE=" + EncodeURL(amexImage) +
                "&DISCOVER_IMAGE=" + EncodeURL(discoverImage);
            }
            return output;
        }

        /// <summary>
        /// Adds optional protected keys to a string. Must be used with GenerateURL.
        /// </summary>
        public string AddDefProtectedStatus(string input)
        {
            if (protectAmount == "Yes")
                input = input + " AMOUNT";
            if (rebillProtect == "Yes")
                input = input + " REBILLING REB_CYCLES REB_AMOUNT REB_EXPR REB_FIRST_DATE";
            if (protectCustomID1 == "Yes")
                input = input + " CUSTOM_ID";
            if (protectCustomID2 == "Yes")
                input = input + " CUSTOM_ID2";
            return input;
        }

        /// <summary>
        /// Adds optional protected values to a string. Must be used with GenerateURL.
        /// </summary>
        public string AddStringProtectedStatus(string input)
        {
            if (protectAmount == "Yes")
                input = input + amount;
            if (rebillProtect == "Yes")
                input = input + doRebill + rebillCycles + rebillAmount + rebillExpr + rebillFirstDate;
            if (protectCustomID1 == "Yes")
                input = input + customID1;
            if (protectCustomID2 == "Yes")
                input = input + customID2;
            return input;
        }

        /// <summary>
        /// Encodes a string into a URL. Must be used with GenerateURL.
        /// </summary>
        public string EncodeURL(string input)
        {
            StringBuilder encodedString = new StringBuilder();
            foreach (char character in input)
            {
                bool isLetterOrDigit = char.IsLetterOrDigit(character);
                if (isLetterOrDigit)
                    encodedString.Append(character.ToString());
                else
                {
                    int value = Convert.ToInt32(character);
                    string hexOutput = String.Format("{0:X}", value);
                    encodedString.Append("%").Append(hexOutput);
                }
            }
            return encodedString.ToString();
        }

        /// <summary>
        /// Generates a Tamperproof Seal for a url. Must be used with GenerateURL.
        /// </summary>
        public string CalcURLTps(string input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        /// <summary>
        /// Generates the final url for the Simple Hosted Payment Form. Must be used with GenerateURL.
        /// </summary>
        public string CalcURLResponse()
        {
            return
            "https://secure.bluepay.com/interfaces/shpf?" +
            "SHPF_FORM_ID=" + EncodeURL(shpfFormID) +
            "&SHPF_ACCOUNT_ID=" + EncodeURL(accountID) +
            "&SHPF_TPS_DEF=" + EncodeURL(shpfTpsDef) +
            "&SHPF_TPS=" + EncodeURL(shpfTamperProofSeal) +
            "&MODE=" + EncodeURL(mode) +
            "&TRANSACTION_TYPE=" + EncodeURL(transType) +
            "&DBA=" + EncodeURL(dba) +
            "&AMOUNT=" + EncodeURL(amount) +
            "&TAMPER_PROOF_SEAL=" + EncodeURL(bp10emuTamperProofSeal) +
            "&CUSTOM_ID=" + EncodeURL(customID1) +
            "&CUSTOM_ID2=" + EncodeURL(customID2) +
            "&REBILLING=" + EncodeURL(doRebill) +
            "&REB_CYCLES=" + EncodeURL(rebillCycles) +
            "&REB_AMOUNT=" + EncodeURL(rebillAmount) +
            "&REB_EXPR=" + EncodeURL(rebillExpr) +
            "&REB_FIRST_DATE=" + EncodeURL(rebillFirstDate) +
            "&AMEX_IMAGE=" + EncodeURL(amexImage) +
            "&DISCOVER_IMAGE=" + EncodeURL(discoverImage) +
            "&REDIRECT_URL=" + EncodeURL(receiptURL) +
            "&TPS_DEF=" + EncodeURL(bp10emuTpsDef) +
            "&CARD_TYPES=" + EncodeURL(cardTypes);
        }

        public string Process()
        {
            string postData = "";

            switch (this.api)
            {
                // A switch section can have more than one case label. 
                case "bpdailyreport2":
                    CalcReportTPS();
                    this.URL = "https://secure.bluepay.com/interfaces/bpdailyreport2";
                    postData += "ACCOUNT_ID=" + HttpUtility.UrlEncode(this.accountID) +
                    "&MODE=" + HttpUtility.UrlEncode(this.mode) +
                    "&TAMPER_PROOF_SEAL=" + HttpUtility.UrlEncode(this.TPS) +
                    "&REPORT_START_DATE=" + HttpUtility.UrlEncode(this.reportStartDate) +
                    "&REPORT_END_DATE=" + HttpUtility.UrlEncode(this.reportEndDate) +
                    "&DO_NOT_ESCAPE=" + HttpUtility.UrlEncode(this.doNotEscape) +
                    "&QUERY_BY_SETTLEMENT=" + HttpUtility.UrlEncode(this.queryBySettlement) +
                    "&QUERY_BY_HIERARCHY=" + HttpUtility.UrlEncode(this.queryByHierarchy) +
                    "&EXCLUDE_ERRORS=" + HttpUtility.UrlEncode(this.excludeErrors);
                    break;
                case "stq":
                    CalcReportTPS();
                    this.URL = "https://secure.bluepay.com/interfaces/stq";
                    postData += "ACCOUNT_ID=" + HttpUtility.UrlEncode(this.accountID) +
                    "&MODE=" + HttpUtility.UrlEncode(this.mode) +
                    "&TAMPER_PROOF_SEAL=" + HttpUtility.UrlEncode(this.TPS) +
                    "&REPORT_START_DATE=" + HttpUtility.UrlEncode(this.reportStartDate) +
                    "&REPORT_END_DATE=" + HttpUtility.UrlEncode(this.reportEndDate) +
                    "&EXCLUDE_ERRORS=" + HttpUtility.UrlEncode(this.excludeErrors);
                    postData += (this.masterID != "") ? "&id=" + HttpUtility.UrlEncode(this.masterID) : "";
                    postData += (this.paymentType != "") ? "&payment_type=" + HttpUtility.UrlEncode(this.paymentType) : "";
                    postData += (this.transType != "") ? "&trans_type=" + HttpUtility.UrlEncode(this.transType) : "";
                    postData += (this.amount != "") ? "&amount=" + HttpUtility.UrlEncode(this.amount) : "";
                    postData += (this.name1 != "") ? "&name1=" + HttpUtility.UrlEncode(this.name1) : "";
                    postData += (this.name2 != "") ? "&name2=" + HttpUtility.UrlEncode(this.name2) : "";
                    break;
                case "bp10emu":
                    CalcTPS();
                    this.URL = "https://secure.bluepay.com/interfaces/bp10emu";
                    postData += "MERCHANT=" + HttpUtility.UrlEncode(this.accountID) +
                    "&MODE=" + HttpUtility.UrlEncode(this.mode) +
                    "&TRANSACTION_TYPE=" + HttpUtility.UrlEncode(this.transType) +
                    "&TAMPER_PROOF_SEAL=" + HttpUtility.UrlEncode(this.TPS) +
                    "&NAME1=" + HttpUtility.UrlEncode(this.name1) +
                    "&NAME2=" + HttpUtility.UrlEncode(this.name2) +
                    "&AMOUNT=" + HttpUtility.UrlEncode(this.amount) +
                    "&ADDR1=" + HttpUtility.UrlEncode(this.addr1) +
                    "&ADDR2=" + HttpUtility.UrlEncode(this.addr2) +
                    "&CITY=" + HttpUtility.UrlEncode(this.city) +
                    "&STATE=" + HttpUtility.UrlEncode(this.state) +
                    "&ZIPCODE=" + HttpUtility.UrlEncode(this.zip) +
                    "&COMMENT=" + HttpUtility.UrlEncode(this.memo) +
                    "&PHONE=" + HttpUtility.UrlEncode(this.phone) +
                    "&EMAIL=" + HttpUtility.UrlEncode(this.email) +
                    "&REBILLING=" + HttpUtility.UrlEncode(this.doRebill) +
                    "&REB_FIRST_DATE=" + HttpUtility.UrlEncode(this.rebillFirstDate) +
                    "&REB_EXPR=" + HttpUtility.UrlEncode(this.rebillExpr) +
                    "&REB_CYCLES=" + HttpUtility.UrlEncode(this.rebillCycles) +
                    "&REB_AMOUNT=" + HttpUtility.UrlEncode(this.rebillAmount) +
                    "&RRNO=" + HttpUtility.UrlEncode(this.masterID) +
                    "&PAYMENT_TYPE=" + HttpUtility.UrlEncode(this.paymentType) +
                    "&INVOICE_ID=" + HttpUtility.UrlEncode(this.invoiceID) +
                    "&ORDER_ID=" + HttpUtility.UrlEncode(this.orderID) +
                    "&CUSTOM_ID=" + HttpUtility.UrlEncode(this.customID1) +
                    "&CUSTOM_ID2=" + HttpUtility.UrlEncode(this.customID2) +
                    "&AMOUNT_TIP=" + HttpUtility.UrlEncode(this.amountTip) +
                    "&AMOUNT_TAX=" + HttpUtility.UrlEncode(this.amountTax) +
                    "&AMOUNT_FOOD=" + HttpUtility.UrlEncode(this.amountFood) +
                    "&AMOUNT_MISC=" + HttpUtility.UrlEncode(this.amountMisc) +
                    "&REMOTE_IP=" + System.Net.Dns.GetHostEntry("").AddressList[0].ToString() +
                    "&TPS_HASH_TYPE=" + HttpUtility.UrlEncode("SHA512") +
                    "&RESPONSEVERSION=3";
                    if (this.swipeData != "")
                    {
                        Match matchTrack1And2 = track1And2.Match(this.swipeData);
                        Match matchTrack2 = track2Only.Match(this.swipeData);
                        if (matchTrack1And2.Success)
                            postData = postData + "&SWIPE=" + HttpUtility.UrlEncode(this.swipeData);
                        else if (matchTrack2.Success)
                            postData = postData + "&TRACK2=" + HttpUtility.UrlEncode(this.swipeData);
                    }
                    else if (this.paymentType == "CREDIT")
                    {
                        postData = postData + "&CC_NUM=" + HttpUtility.UrlEncode(this.paymentAccount) +
                        "&CC_EXPIRES=" + HttpUtility.UrlEncode(this.cardExpire) +
                        "&CVCCVV2=" + HttpUtility.UrlEncode(this.cvv2);
                    }
                    else
                    {
                        postData = postData + "&ACH_ROUTING=" + HttpUtility.UrlEncode(this.routingNum) +
                        "&ACH_ACCOUNT=" + HttpUtility.UrlEncode(this.accountNum) +
                        "&ACH_ACCOUNT_TYPE=" + HttpUtility.UrlEncode(this.accountType) +
                        "&DOC_TYPE=" + HttpUtility.UrlEncode(this.docType);
                    }
                    break;
                case "bp20rebadmin":
                    CalcRebillTPS();
                    this.URL = "https://secure.bluepay.com/interfaces/bp20rebadmin";
                    postData += "ACCOUNT_ID=" + HttpUtility.UrlEncode(this.accountID) +
                    "&TAMPER_PROOF_SEAL=" + HttpUtility.UrlEncode(this.TPS) +
                    "&TRANS_TYPE=" + HttpUtility.UrlEncode(this.transType) +
                    "&REBILL_ID=" + HttpUtility.UrlEncode(this.rebillID) +
                    "&TEMPLATE_ID=" + HttpUtility.UrlEncode(this.templateID) +
                    "&REB_EXPR=" + HttpUtility.UrlEncode(this.rebillExpr) +
                    "&REB_CYCLES=" + HttpUtility.UrlEncode(this.rebillCycles) +
                    "&REB_AMOUNT=" + HttpUtility.UrlEncode(this.rebillAmount) +
                    "&NEXT_AMOUNT=" + HttpUtility.UrlEncode(this.rebillNextAmount) +
                    "&NEXT_DATE=" + HttpUtility.UrlEncode(this.rebillNextDate) +
                    "&STATUS=" + HttpUtility.UrlEncode(this.rebillStatus);
                    break;
                default:
                    Console.WriteLine("Error: Must call a valid api");
                    break;
            }

            PerformPost(postData);
            return GetStatus();
        }

        public void PerformPost(string post)
        {
            //Create HTTPS POST object and send to BluePay
            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(this.URL));
            request.AllowAutoRedirect = false;

            ServicePointManager.CheckCertificateRevocationList = true;

            byte[] data = encoding.GetBytes(post);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            try
            {
                Stream postdata = request.GetRequestStream();
                postdata.Write(data, 0, data.Length);
                postdata.Close();

                // Get response
                GetResponse(request);
            }
            catch (WebException e)
            {

                HttpWebResponse httpResponse = (HttpWebResponse)e.Response;
                try
                {
                    GetResponse(e, post);
                    httpResponse.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error has occurred while connecting to BluePay. Retrying connection...");
                }
            }
        }

        public void GetResponse(HttpWebRequest request)
        {
            HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse();

            // add this line to match previous library
            response = httpResponse.GetResponseHeader("Location");
            httpResponse.Close();
        }

        public void GetResponse(WebException request, string postData)
        {
            // Due to how Microsoft handles SSL/TLS session caching, a retry on a failed connection with an expired set of keys may be necessary.
            if (numRetries < 1 && request.Message == "The request was aborted: Could not create SSL/TLS secure channel.")
            {
                numRetries++;
                PerformPost(postData);
                return;
            }
            HttpWebResponse httpResponse = (HttpWebResponse)request.Response;

        }

        public bool IsSuccessfulTransaction()
        {
            string status = this.GetStatus();
            string message = this.GetMessage();
            return (status == "APPROVED" && message != "DUPLICATE");
        }

        /// <summary>
        /// Returns STATUS or status from response
        /// </summary>
        /// <returns></returns>
        public string GetStatus()
        {
            Regex r = new Regex(@"Result=([^&$]*)");
            Match m = r.Match(response);
            if (m.Success)
                return (m.Value.Substring(7));
            r = new Regex(@"status=([^&$]*)");
            m = r.Match(response);
            if (m.Success)
                return (m.Value.Substring(7));
            else
                return "";
        }

        /// <summary>
        /// Returns TRANS_ID from response
        /// </summary>
        /// <returns></returns>
        public string GetTransID()
        {
            Regex r = new Regex(@"RRNO=([^&$]*)");
            Match m = r.Match(response);
            if (m.Success)
                return (m.Value.Substring(5));
            else
                return "";
        }

        /// <summary>
        /// Returns MESSAGE from Response
        /// </summary>
        /// <returns></returns>
        public string GetMessage()
        {
            Regex r = new Regex(@"MESSAGE=([^&$]+)");
            Match m = r.Match(response);
            if (m.Success)
            {
                string[] message = m.Value.Substring(8).Split('"');
                return message[0];
            }
            else
                return "";
        }

        /// <summary>
        /// Returns CVV2 from Response
        /// </summary>
        /// <returns></returns>
        public string GetCVV2()
        {
            Regex r = new Regex(@"CVV2=([^&$]*)");
            Match m = r.Match(response);
            if (m.Success)
                return m.Value.Substring(5);
            else
                return "";
        }

        /// <summary>
        /// Returns AVS from Response
        /// </summary>
        /// <returns></returns>
        public string GetAVS()
        {
            Regex r = new Regex(@"AVS=([^&$]+)");
            Match m = r.Match(response);
            if (m.Success)
                return m.Value.Substring(4);
            else
                return "";
        }

        /// <summary>
        /// Returns PAYMENT_ACCOUNT from response
        /// </summary>
        /// <returns></returns>
        public string GetMaskedPaymentAccount()
        {
            Regex r = new Regex("PAYMENT_ACCOUNT=([^&$]+)");
            Match m = r.Match(response);
            if (m.Success)
                return m.Value.Substring(16);
            else
                return "";
        }

        /// <summary>
        /// Returns CARD_TYPE from response
        /// </summary>
        /// <returns></returns>
        public string GetCardType()
        {
            Regex r = new Regex("CARD_TYPE=([^&$]+)");
            Match m = r.Match(response);
            if (m.Success)
                return m.Value.Substring(10);
            else
                return "";
        }

        /// <summary>
        /// Returns BANK_NAME from Response
        /// </summary>
        /// <returns></returns>
        public string GetBank()
        {
            Regex r = new Regex("BANK_NAME=([^&$]+)");
            Match m = r.Match(response);
            if (m.Success)
                return m.Value.Substring(10);
            else
                return "";
        }

        /// <summary>
        /// Returns AUTH_CODE from Response
        /// </summary>
        /// <returns></returns>
        public string GetAuthCode()
        {
            Regex r = new Regex(@"AUTH_CODE=([^&$]+)");
            Match m = r.Match(response);
            if (m.Success)
                return (m.Value.Substring(10));
            else
                return "";
        }
        /// <summary>
        /// Returns REBID or rebill_id from Response
        /// </summary>
        /// <returns></returns>
        public string GetRebillID()
        {
            Regex r = new Regex(@"REBID=([^&$]+)");
            Match m = r.Match(response);
            if (m.Success)
                return (m.Value.Substring(6));
            r = new Regex(@"rebill_id=([^&$]+)");
            m = r.Match(response);
            if (m.Success)
                return (m.Value.Substring(10));
            else
                return "";
        }

        /// <summary>
        /// Returns creation_date from Response
        /// </summary>
        /// <returns></returns>
        public string GetCreationDate()
        {
            Regex r = new Regex(@"creation_date=([^&$]+)");
            Match m = r.Match(response);
            if (m.Success)
                return (m.Value.Substring(14));
            else
                return "";
        }

        /// <summary>
        /// Returns next_date from Response
        /// </summary>
        /// <returns></returns>
        public string GetNextDate()
        {
            Regex r = new Regex(@"next_date=([^&$]+)");
            Match m = r.Match(response);
            if (m.Success)
                return (m.Value.Substring(10));
            else
                return "";
        }

        /// <summary>
        /// Returns last_date from Response
        /// </summary>
        /// <returns></returns>
        public string GetLastDate()
        {
            Regex r = new Regex(@"last_date=([^&$]+)");
            Match m = r.Match(response);
            if (m.Success)
                return (m.Value.Substring(9));
            else
                return "";
        }

        /// <summary>
        /// Returns sched_expr from Response
        /// </summary>
        /// <returns></returns>
        public string GetSchedExpr()
        {
            Regex r = new Regex(@"sched_expr=([^&$]+)");
            Match m = r.Match(response);
            if (m.Success)
                return (m.Value.Substring(11));
            else
                return "";
        }

        /// <summary>
        /// Returns cycles_remain from Response
        /// </summary>
        /// <returns></returns>
        public string GetCyclesRemain()
        {
            Regex r = new Regex(@"cycles_remain=([^&$]+)");
            Match m = r.Match(response);
            if (m.Success)
                return (m.Value.Substring(14));
            else
                return "";
        }

        /// <summary>
        /// Returns reb_amount from Response
        /// </summary>
        /// <returns></returns>
        public string GetRebillAmount()
        {
            Regex r = new Regex(@"reb_amount=([^&$]+)");
            Match m = r.Match(response);
            if (m.Success)
                return (m.Value.Substring(11));
            else
                return "";
        }

        /// <summary>
        /// Returns next_amount from Response
        /// </summary>
        /// <returns></returns>
        public string GetNextAmount()
        {
            Regex r = new Regex(@"next_amount=([^&$]+)");
            Match m = r.Match(response);
            if (m.Success)
                return (m.Value.Substring(12));
            else
                return "";
        }
    }
}