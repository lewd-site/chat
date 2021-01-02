module.exports = {
    purge: [
        './Pages/**/*.cshtml',
    ],
    darkMode: false,
    theme: {
        extend: {},
        screens: {
            sm: '600px',
            md: '900px',
            lg: '1200px',
            xl: '1500px',
            '2xl': '1800px',
        },
        colors: {
            white: '#EEEEEE',
            gray: {
                light: '#9DA2B2',
                DEFAULT: '#43474F',
                dark: '#36393F',
                darker: '#303339',
            },
        },
        fontFamily: {
            'sans': [
                '"Open Sans"', 'ui-sans-serif', 'system-ui', '-apple-system', 'BlinkMacSystemFont',
                '"Segoe UI"', 'Roboto', '"Helvetica Neue"', 'Arial', '"Noto Sans"', 'sans-serif',
                '"Apple Color Emoji"', '"Segoe UI Emoji"', '"Segoe UI Symbol"', '"Noto Color Emoji"',
            ],
        },
    },
    variants: {
        extend: {},
    },
    plugins: [],
};
