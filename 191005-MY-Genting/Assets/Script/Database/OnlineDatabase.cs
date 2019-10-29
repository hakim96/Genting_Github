using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using DataBank;

public class OnlineDatabase : MonoBehaviour
{
    public const string userURL = "https://www.google.com/";
    public const string dupreferURL = "https://www.google.com/";
    public const string voucherdistributionURL = "https://www.google.com/";

    public UserDatabase userdb;
    public DupReferDatabase duprdb;
    public VoucherDistributionDatabase vddb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Sync User Data Online
    public void SyncUserData()
    {
        userdb.ClearList();
        userdb.GetDataByOnlineStatus();
        StartCoroutine(UserData());
    }
    IEnumerator UserData()
    {
        foreach(UserEntity a in userdb.myList)
        {
            WWWForm form = new WWWForm();
            form.AddField("name", a._name);
            form.AddField("contact", a._phone);
            form.AddField("email", a._email);
            form.AddField("isNewMember", a._status);
            form.AddField("card_number", a._memberid);
            form.AddField("reference_code", a._referencecode);
            form.AddField("register_datetime", a._dateCreated);
            using (UnityWebRequest www = UnityWebRequest.Post(userURL, form))
            {
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log(www.error);
                    break;
                }
                else
                {
                    Debug.Log("User Form upload complete!");
                    userdb.UpdateDataOnline(a);
                }
            }
        }
    }
    #endregion

    #region Sync DoubleUp Reference Data
    public void SyncDupReferData()
    {
        duprdb.ClearList();
        duprdb.GetDataByOnlineStatus();
        StartCoroutine(DupReferData());
    }
    IEnumerator DupReferData()
    {
        foreach(DupReferEntity s in duprdb.myList)
        {
            WWWForm form = new WWWForm();
            form.AddField("referer_contact", s._userphone);
            form.AddField("referral_name", s._name);
            form.AddField("referral_contact", s._phone);
            form.AddField("referral_email", s._email);
            using (UnityWebRequest www = UnityWebRequest.Post(dupreferURL, form))
            {
                yield return www.SendWebRequest();

                if(www.isNetworkError || www.isHttpError)
                {
                    Debug.Log(www.error);
                    break;
                }
                else
                {
                    Debug.Log("DoubleUp Reference Form upload complete!");
                    duprdb.UpdateOnlineStatusData(s);
                }
            }
        }
    }
    #endregion

    #region Sync Voucher Distribution Data
    public void SynchVoucherDistributionData()
    {
        vddb.ClearList();
        vddb.GetDataByStatus();
        StartCoroutine(VoucherDistributionData());
    }
    IEnumerator VoucherDistributionData()
    {
        foreach (VoucherDistributionEntity d in vddb.myList)
        {
            WWWForm form = new WWWForm();
            form.AddField("player_contact", d._userPhone);
            form.AddField("voucher_code", d._voucherID);
            using (UnityWebRequest www = UnityWebRequest.Post(voucherdistributionURL, form))
            {
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log(www.error);
                    break;
                }
                else
                {
                    Debug.Log("User Form upload complete!");
                    vddb.UpdateOnlineStatusData(d);
                }
            }
        }
    }
    #endregion
}
