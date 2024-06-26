using UnityEngine;
using UnityEngine.UI;

public class SelectArrow : MonoBehaviour
{
    [SerializeField] private RectTransform[] buttons;
    private RectTransform arrow;
    private int currentPosition;

    private void Awake()
    {
        arrow = GetComponent<RectTransform>();
    }
    private void OnEnable()
    {
        currentPosition = 0;
        ChangePosition(0);
    }
    private void Update()
    {
        //Change the position of the selection arrow
        if (Input.GetKeyDown(KeyCode.UpArrow))
            ChangePosition(1);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            ChangePosition(-1);

        //Interact with current option
        if (Input.GetKeyDown(KeyCode.Return))
            Interact();
    }

    private void ChangePosition(int _change)
    {
        currentPosition += _change;


        if (currentPosition < 0)
            currentPosition = buttons.Length - 1;
        else if (currentPosition > buttons.Length - 1)
            currentPosition = 0;

        AssignPosition();
    }
    private void AssignPosition()
    {
        //Assign the Y position of the current option to the arrow (basically moving it up and down)
        arrow.position = new Vector3(arrow.position.x, buttons[currentPosition].position.y);
    }
    private void Interact()
    {
        //Access the button component on each option and call its function
        buttons[currentPosition].GetComponent<Button>().onClick.Invoke();
    }
}