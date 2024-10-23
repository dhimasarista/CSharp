namespace Algorithms;

class NeuralNetwork
{
    private int inputLayerSize, hiddenLayerSize, outputLayerSize;
    private double[,] inputWeights, hiddenWeights;
    private double[] hiddenBiases, outputBiases;
    private double learningRate;

    // Constructor to initialize the network
    public NeuralNetwork(int inputSize, int hiddenSize, int outputSize, double learningRate)
    {
        inputLayerSize = inputSize;
        hiddenLayerSize = hiddenSize;
        outputLayerSize = outputSize;
        this.learningRate = learningRate;

        inputWeights = new double[inputLayerSize, hiddenLayerSize];
        hiddenWeights = new double[hiddenLayerSize, outputLayerSize];
        hiddenBiases = new double[hiddenLayerSize];
        outputBiases = new double[outputLayerSize];

        RandomizeWeights();
    }

    // Randomize weights for initialization
    private void RandomizeWeights()
    {
        Random rand = new Random();
        for (int i = 0; i < inputLayerSize; i++)
            for (int j = 0; j < hiddenLayerSize; j++)
                inputWeights[i, j] = rand.NextDouble();

        for (int i = 0; i < hiddenLayerSize; i++)
            for (int j = 0; j < outputLayerSize; j++)
                hiddenWeights[i, j] = rand.NextDouble();

        for (int i = 0; i < hiddenLayerSize; i++)
            hiddenBiases[i] = rand.NextDouble();

        for (int i = 0; i < outputLayerSize; i++)
            outputBiases[i] = rand.NextDouble();
    }

    // Activation function (Sigmoid)
    private double Sigmoid(double x) => 1.0 / (1.0 + Math.Exp(-x));

    // Derivative of the Sigmoid function
    private double SigmoidDerivative(double x) => x * (1 - x);

    // Forward pass through the network
    public double[] FeedForward(double[] inputs)
    {
        // Hidden layer
        double[] hiddenOutputs = new double[hiddenLayerSize];
        for (int i = 0; i < hiddenLayerSize; i++)
        {
            hiddenOutputs[i] = hiddenBiases[i];
            for (int j = 0; j < inputLayerSize; j++)
                hiddenOutputs[i] += inputs[j] * inputWeights[j, i];
            hiddenOutputs[i] = Sigmoid(hiddenOutputs[i]);
        }

        // Output layer
        double[] finalOutputs = new double[outputLayerSize];
        for (int i = 0; i < outputLayerSize; i++)
        {
            finalOutputs[i] = outputBiases[i];
            for (int j = 0; j < hiddenLayerSize; j++)
                finalOutputs[i] += hiddenOutputs[j] * hiddenWeights[j, i];
            finalOutputs[i] = Sigmoid(finalOutputs[i]);
        }

        return finalOutputs;
    }

    // Backpropagation algorithm
    public void Backpropagate(double[] inputs, double[] expectedOutputs)
    {
        // Forward pass
        double[] hiddenOutputs = new double[hiddenLayerSize];
        for (int i = 0; i < hiddenLayerSize; i++)
        {
            hiddenOutputs[i] = hiddenBiases[i];
            for (int j = 0; j < inputLayerSize; j++)
                hiddenOutputs[i] += inputs[j] * inputWeights[j, i];
            hiddenOutputs[i] = Sigmoid(hiddenOutputs[i]);
        }

        double[] finalOutputs = new double[outputLayerSize];
        for (int i = 0; i < outputLayerSize; i++)
        {
            finalOutputs[i] = outputBiases[i];
            for (int j = 0; j < hiddenLayerSize; j++)
                finalOutputs[i] += hiddenOutputs[j] * hiddenWeights[j, i];
            finalOutputs[i] = Sigmoid(finalOutputs[i]);
        }

        // Output layer error
        double[] outputErrors = new double[outputLayerSize];
        for (int i = 0; i < outputLayerSize; i++)
            outputErrors[i] = expectedOutputs[i] - finalOutputs[i];

        // Hidden layer error
        double[] hiddenErrors = new double[hiddenLayerSize];
        for (int i = 0; i < hiddenLayerSize; i++)
        {
            hiddenErrors[i] = 0;
            for (int j = 0; j < outputLayerSize; j++)
                hiddenErrors[i] += outputErrors[j] * hiddenWeights[i, j] * SigmoidDerivative(finalOutputs[j]);
        }

        // Update weights for hidden to output layer
        for (int i = 0; i < hiddenLayerSize; i++)
            for (int j = 0; j < outputLayerSize; j++)
                hiddenWeights[i, j] += learningRate * outputErrors[j] * SigmoidDerivative(finalOutputs[j]) * hiddenOutputs[i];

        // Update biases for output layer
        for (int i = 0; i < outputLayerSize; i++)
            outputBiases[i] += learningRate * outputErrors[i] * SigmoidDerivative(finalOutputs[i]);

        // Update weights for input to hidden layer
        for (int i = 0; i < inputLayerSize; i++)
            for (int j = 0; j < hiddenLayerSize; j++)
                inputWeights[i, j] += learningRate * hiddenErrors[j] * SigmoidDerivative(hiddenOutputs[j]) * inputs[i];

        // Update biases for hidden layer
        for (int i = 0; i < hiddenLayerSize; i++)
            hiddenBiases[i] += learningRate * hiddenErrors[i] * SigmoidDerivative(hiddenOutputs[i]);
    }
}