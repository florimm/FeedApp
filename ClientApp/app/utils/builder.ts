const REQUEST = 'REQUEST';
const SUCCESS = 'SUCCESS';
const FAILURE = 'FAILURE';

export interface IType {
  REQUEST: string,
  SUCCESS: string,
  FAILURE: string
}

export default function (name) {
  function createSync(base) {
    return `${name}__${base}`;
  }
  function createAsync(base) {
    return [REQUEST, SUCCESS, FAILURE].reduce((acc, type) => {
      // eslint-disable-next-line no-param-reassign
      acc[type] = `${name}__${base}__${type}`;
      return acc;
    }, {});
  }
  return {
    sync: createSync,
    async: createAsync,
  };
}
