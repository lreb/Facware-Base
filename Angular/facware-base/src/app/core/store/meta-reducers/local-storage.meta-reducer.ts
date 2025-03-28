
export function localStorageMetaReducer(reducer: any) {
  return (state: any, action: any) => {
    if (typeof window !== 'undefined' && window.localStorage) {
      const savedState = localStorage.getItem('cart');
      if (savedState) state = JSON.parse(savedState);
    }
    const newState = reducer(state, action);
    localStorage.setItem('cart', JSON.stringify(newState));
    return newState;
  };
}
