using Level;
using UnityEngine;

namespace Player
{
    public class CoinPickup : MonoBehaviour
    {
        private int _coinsAmount;
        public delegate void NotifyCoinsAmountUpdate(int amount);
        public static event NotifyCoinsAmountUpdate OnCoinPickupEvent;
    
        private void Start()
        {
            _coinsAmount = 0;
        }

        private void OnTriggerEnter(Collider coin)
        {
            if (!coin.TryGetComponent<CoinBehavior>(out _))
            {
                return;
            }
            Destroy(coin.gameObject);
            _coinsAmount += 1;
            OnCoinPickupEvent?.Invoke(_coinsAmount);
        }
    }
}
