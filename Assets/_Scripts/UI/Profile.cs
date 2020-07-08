using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    /**-----------I AM NOT USING THIS SCRIPT

    #region Singleton:Profile
    public static Profile instance;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public class Avatar
    {
        public Sprite Image;
    }

    public List<Avatar> AvatarsList;
    [SerializeField] GameObject AvatarUITemplate;
    [SerializeField] Transform AvatarsScrollView;
    GameObject g;
    int newSelectedIndex, previousSelectedindex;
    [SerializeField] Color ActiveAvatarColor;
    [SerializeField] Color DefaultAvatarColor;
    [SerializeField] Image CurrentAvatar;
    private void Start()
    {
        GetAvailableAvatars();
        newSelectedIndex = previousSelectedindex = 0;
    }

    void GetAvailableAvatars()
    {
        for (int i=0;i<Shop.instance.ShopItemsList.Count;i++)
        {
            if (Shop.instance.ShopItemsList[i].isPurchased)
            {
                AddAvatar(Shop.instance.ShopItemsList[i].image);
            }
        }

        SelectAvatar(newSelectedIndex);
    }

    void AddAvatar(Sprite img)
    {
        if (AvatarsList==null)
        {
            AvatarsList = new List<Avatar>();
        }
        Avatar av = new Avatar() { Image = img };   
        
        AvatarsList.Add(av);

        g = Instantiate(AvatarUITemplate,AvatarsScrollView);
        g.transform.GetChild(0).GetComponent<Image>().sprite = av.Image;

        g.transform.GetComponent<Button>().AddEventListener(AvatarsList.Count-1,OnAvatarClick);
    }

    void OnAvatarClick( int AvatarIndex)
    {
        SelectAvatar(AvatarIndex);
    }

    void SelectAvatar(int AvatarIndex)
    {
        previousSelectedindex = newSelectedIndex;
        newSelectedIndex = AvatarIndex;
        AvatarsScrollView.GetChild(previousSelectedindex).GetComponent<Image>().color = DefaultAvatarColor;
        AvatarsScrollView.GetChild(newSelectedIndex).GetComponent<Image>().color = ActiveAvatarColor;

        CurrentAvatar.sprite = AvatarsList[newSelectedIndex].Image;
    }
    -----------**/
}
