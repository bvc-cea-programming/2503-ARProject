using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace LeoEsguerra
{
    public class TargetController : MonoBehaviour
    {
        private bool _isRotating = false;
        private bool _isShowing = true;
        private bool _isMoving = false;

        public Button[] controlButtons;
        private Vector3[] _originalPositions;
        private Vector3[] _originalRotations;
        [SerializeField] private GameObject[] _targetObjects;

        private void Start()
        {
            _originalPositions = new Vector3[_targetObjects.Length];
            _originalRotations = new Vector3[_targetObjects.Length];

            for (int i = 0; i < _targetObjects.Length; i++)
            {
                if(_targetObjects[i] != null)
                {
                    _originalPositions[i] = _targetObjects[i].transform.localPosition;
                    _originalRotations[i] = _targetObjects[i].transform.localEulerAngles;
                }
                else
                {
                    Debug.LogError("Target Object is null: " + i);
                }
            }
        }

        public void OnTargetFound()
        {
            EnableButtons();
        }

        public void OnTargetLost()
        {
            DisableButtons();
        }

        private void EnableButtons()
        {
            foreach (Button button in controlButtons)
            {
                button.interactable = true;
            }
        }

        private void DisableButtons()
        {
            foreach (Button button in controlButtons)
            {
                button.interactable = false;
            }
        }

        public void ShowObjects()
        {
            if(_isMoving || _isShowing)
            {
                return;
            }
            
            for (int i = 0; i < _targetObjects.Length; i++)
            {
                _targetObjects[i].transform.DOLocalMove(_originalPositions[i], 1f).OnComplete(() =>
                {
                    _isMoving = false;
                    _isShowing = true;
                });
            }
        }

        public void HideObjects()
        {
            if(!_isShowing)
            {
                return;
            }

            StopRotateObjects();

            for (int i = 0; i < _targetObjects.Length; i++)
            {
                _targetObjects[i].transform.DOLocalMove(new Vector3(0, 0, 0), 1f).OnComplete(() =>
                {
                    _isMoving = false;
                    _isShowing = false;
                });
            }
        }

        public void RotateObjects()
        {
            if(_isMoving || !_isShowing)
            {
                return;
            }   

            if(!_isRotating)
            {
                _isRotating = true;
                Debug.Log("isRotating: " + _isRotating);
                for (int i = 0; i < _targetObjects.Length; i++)
                {
                    _targetObjects[i].transform.GetChild(0).transform.DOLocalRotate(new Vector3(0, 90, 0), 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
                }
            }
            else
            {
                StopRotateObjects();
            }
        }

        public void StopRotateObjects()
        {
            if(!_isRotating || _isMoving)
            {
                return;
            }

            for (int i = 0; i < _targetObjects.Length; i++)
            {
                _targetObjects[i].transform.GetChild(0).transform.DOKill();
            }

            _isRotating = false;
        }
    }
}