import {render, screen, cleanup} from '@testing-library/react';
import {Login} from '../Login';
import { Register } from '../Register';

afterEach(()=>{
    cleanup();
});


const mockedUsedNavigate = jest.fn();

jest.mock('react-router-dom', () => ({
   ...jest.requireActual('react-router-dom'),
  useNavigate: () => mockedUsedNavigate,
}));

test('should render Login component', ()=>{
    render(<Login />);
    const LoginElement = screen.getAllByTestId('testLogin');
    const LoginFormElement = screen.getAllByTestId('testLoginForm');
    const LoginFormButton = screen.getAllByTestId('testLoginFormButton');

    expect(LoginElement[0]).toBeInTheDocument();
    expect(LoginFormElement[0]).toHaveFormValues({
        userName : "",
        Password : ""
    })
    expect(LoginFormButton[0]).toHaveAttribute('type','submit');
})

test('sould render Register component', ()=> {
    render(<Register/>);
    const registerElement = screen.getAllByTestId('testRegister');
    const inputElement = screen.getAllByTestId('testEmailInput');

    expect(registerElement[0]).toBeInTheDocument();
    expect(registerElement[0]).toContainElement(inputElement[0]);
})